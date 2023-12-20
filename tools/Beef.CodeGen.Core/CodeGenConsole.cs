﻿// Copyright (c) Avanade. Licensed under the MIT License. See https://github.com/Avanade/Beef

using CoreEx.Abstractions;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using OnRamp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Beef.CodeGen
{
    /// <summary>
    /// <b>Beef</b>-specific code-generation console that inherits from <see cref="OnRamp.Console.CodeGenConsole"/>.
    /// </summary>
    /// <remarks>Command line parsing: https://natemcmaster.github.io/CommandLineUtils/ </remarks>
    public class CodeGenConsole : OnRamp.Console.CodeGenConsole
    {
        private static readonly string[] _countExtensions = [".cs", ".json", ".jsn", ".yaml", ".yml", ".xml", ".sql"];

        private string _entityScript = "EntityWebApiCoreAgent.yaml";
        private string _refDataScript = "RefDataCoreCrud.yaml";
        private string _dataModelScript = "DataModelOnly.yaml";
        private string _databaseScript = "Database.yaml";

        private CommandArgument<CommandType>? _cmdArg;

        /// <summary>
        /// Gets the 'Company' <see cref="CodeGeneratorArgsBase.Parameters"/> name.
        /// </summary>
        public const string CompanyParamName = "Company";

        /// <summary>
        /// Gets the 'AppName' <see cref="CodeGeneratorArgsBase.Parameters"/> name.
        /// </summary>
        public const string AppNameParamName = "AppName";

        /// <summary>
        /// Gets the 'ApiName' <see cref="CodeGeneratorArgsBase.Parameters"/> name.
        /// </summary>
        public const string ApiNameParamName = "ApiName";

        /// <summary>
        /// Gets the 'DatabaseMigrator' <see cref="CodeGeneratorArgsBase.Parameters"/> name.
        /// </summary>
        public const string DatabaseMigratorParamName = "DatabaseMigrator";

        /// <summary>
        /// Gets the default masthead text.
        /// </summary>
        /// <remarks>Defaults to 'Beef Code-Gen Tool' formatted using <see href="http://www.patorjk.com/software/taag/#p=display&amp;f=Calvin%20S&amp;t=Beef%20Code-Gen%20Tool%0A"/>.</remarks>
        public const string DefaultMastheadText = @"
╔╗ ┌─┐┌─┐┌─┐  ╔═╗┌─┐┌┬┐┌─┐  ╔═╗┌─┐┌┐┌  ╔╦╗┌─┐┌─┐┬  
╠╩╗├┤ ├┤ ├┤   ║  │ │ ││├┤───║ ╦├┤ │││   ║ │ ││ ││  
╚═╝└─┘└─┘└    ╚═╝└─┘─┴┘└─┘  ╚═╝└─┘┘└┘   ╩ └─┘└─┘┴─┘
";

        /// <summary>
        /// Creates a new instance of the <see cref="CodeGenConsole"/> class defaulting to <see cref="Assembly.GetCallingAssembly"/>.
        /// </summary>
        /// <param name="company">The company name.</param>
        /// <param name="appName">The application/domain name.</param>
        /// <param name="apiName">The Web API name.</param>
        /// <param name="outputDirectory">The output path/directory; defaults to the resulting <see cref="OnRamp.Console.CodeGenConsole.GetBaseExeDirectory"/> <see cref="DirectoryInfo.Parent"/>.</param>
        /// <returns>The <see cref="CodeGenConsole"/> instance.</returns>
        public static CodeGenConsole Create(string company, string appName, string apiName = "Api", string? outputDirectory = null) => Create(new Assembly[] { Assembly.GetCallingAssembly() }, company, appName, apiName, outputDirectory);

        /// <summary>
        /// Creates a new instance of the <see cref="CodeGenConsole"/> class.
        /// </summary>
        /// <param name="assemblies">The list of additional assemblies to probe for resources.</param>
        /// <param name="company">The company name.</param>
        /// <param name="appName">The application/domain name.</param>
        /// <param name="apiName">The Web API name.</param>
        /// <param name="outputDirectory">The output path/directory; defaults to the resulting <see cref="OnRamp.Console.CodeGenConsole.GetBaseExeDirectory"/> <see cref="DirectoryInfo.Parent"/>.</param>
        /// <returns>The <see cref="CodeGenConsole"/> instance.</returns>
        public static CodeGenConsole Create(Assembly[] assemblies, string company, string appName, string apiName = "Api", string? outputDirectory = null)
        {
            var args = new CodeGeneratorArgs { OutputDirectory = string.IsNullOrEmpty(outputDirectory) ? new DirectoryInfo(GetBaseExeDirectory()).Parent : new DirectoryInfo(outputDirectory) };
            args.AddAssembly(typeof(CodeGenConsole).Assembly);
            args.AddAssembly(assemblies);
            args.AddParameter(CompanyParamName, company ?? throw new ArgumentNullException(nameof(company)));
            args.AddParameter(AppNameParamName, appName ?? throw new ArgumentNullException(nameof(appName)));
            args.AddParameter(ApiNameParamName, apiName ?? throw new ArgumentNullException(nameof(apiName)));
            return new CodeGenConsole(args) { BypassOnWrites = true };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeGenConsole"/> class.
        /// </summary>
        internal CodeGenConsole(CodeGeneratorArgs args) : base(args, OnRamp.Console.SupportedOptions.All)
        {
            MastheadText = DefaultMastheadText;
            Args.CreateConnectionStringEnvironmentVariableName ??= csargs => $"{args.GetCompany()?.Replace(".", "_", StringComparison.InvariantCulture)}_{args.GetAppName()?.Replace(".", "_", StringComparison.InvariantCulture)}_ConnectionString";
        }

        /// <summary>
        /// Indicates whether <see cref="CommandType.Entity"/> is supported (defaults to <c>true</c>).
        /// </summary>
        public bool IsEntitySupported { get; set; } = true;

        /// <summary>
        /// Indicates whether <see cref="CommandType.Database"/> is supported (defaults to <c>false</c>).
        /// </summary>
        public bool IsDatabaseSupported { get; set; } = false;

        /// <summary>
        /// Indicates whether <see cref="CommandType.RefData"/> is supported (defaults to <c>false</c>).
        /// </summary>
        public bool IsRefDataSupported { get; set; } = false;

        /// <summary>
        /// Indicates whether <see cref="CommandType.DataModel"/> is supported (defaults to <c>false</c>).
        /// </summary>
        public bool IsDataModelSupported { get; set; } = false;

        /// <summary>
        /// Sets the <see cref="IsEntitySupported"/>, <see cref="IsDatabaseSupported"/> and <see cref="IsRefDataSupported"/> options.
        /// </summary>
        /// <param name="entity">Indicates whether the entity code generation should take place.</param>
        /// <param name="database">Indicates whether the database generation should take place.</param>
        /// <param name="refData">Indicates whether the reference data generation should take place.</param>
        /// <param name="dataModel">Indicates whether the data model generation should take place.</param>
        /// <returns>The <see cref="CodeGenConsole"/> to support method chaining/fluent style.</returns>
        public CodeGenConsole Supports(bool entity = true, bool database = false, bool refData = false, bool dataModel = false)
        {
            IsEntitySupported = entity;
            IsDatabaseSupported = database;
            IsRefDataSupported = refData;
            IsDataModelSupported = dataModel;
            return this;
        }

        /// <summary>
        /// Sets (overrides) the execution script file or embedded resource name for the <see cref="CommandType.Database"/> (defaults to <c>EntityWebApiCoreAgent.yaml</c>).
        /// </summary>
        /// <param name="script">The execution script file or embedded resource name.</param>
        /// <returns>The current instance to supported fluent-style method-chaining.</returns>
        public CodeGenConsole EntityScript(string script)
        {
            _entityScript = script ?? throw new ArgumentNullException(nameof(script));
            return this;
        }

        /// <summary>
        /// Sets (overrides) the execution script file or embedded resource name for the <see cref="CommandType.DataModel"/> (defaults to <c>DataModelOnly.yaml</c>).
        /// </summary>
        /// <param name="script">The execution script file or embedded resource name.</param>
        /// <returns>The current instance to supported fluent-style method-chaining.</returns>
        public CodeGenConsole DataModelScript(string script)
        {
            _dataModelScript = script ?? throw new ArgumentNullException(nameof(script));
            return this;
        }

        /// <summary>
        /// Sets (overrides) the execution script file or embedded resource name for the <see cref="CommandType.RefData"/> (defaults to <c>RefDataCoreCrud.yaml</c>).
        /// </summary>
        /// <param name="script">The execution script file or embedded resource name.</param>
        /// <returns>The current instance to supported fluent-style method-chaining.</returns>
        public CodeGenConsole RefDataScript(string script)
        {
            _refDataScript = script ?? throw new ArgumentNullException(nameof(script));
            return this;
        }

        /// <summary>
        /// Sets (overrides) the execution script file or embedded resource name for the <see cref="CommandType.Database"/> (defaults to <c>Database.yaml</c>).
        /// </summary>
        /// <param name="script">The execution script file or embedded resource name.</param>
        /// <returns>The current instance to supported fluent-style method-chaining.</returns>
        public CodeGenConsole DatabaseScript(string script)
        {
            _databaseScript = script ?? throw new ArgumentNullException(nameof(script));
            return this;
        }

        /// <summary>
        /// Sets (overrides) the default database connection string.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        /// <returns>The current instance to supported fluent-style method-chaining.</returns>
        /// <remarks>Acts as the default; the command line option '<c>-cs|--connectionString</c>' and environment variable take precedence.</remarks>
        public CodeGenConsole DatabaseConnectionString(string connectionString)
        {
            Args.ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            return this;
        }

        /// <inheritdoc/>
        protected override void OnBeforeExecute(CommandLineApplication app)
        {
            _cmdArg = app.Argument<CommandType>("command", "Execution command type.", false).IsRequired();

            using var sr = Resource.GetStreamReader<CodeGenConsole>("ExtendedHelp.txt");
            app.ExtendedHelpText = sr.ReadToEnd();
        }

        /// <inheritdoc/>
        protected override ValidationResult? OnValidation(ValidationContext context)
        {
            var cmd = _cmdArg!.ParsedValue;
            if (cmd == CommandType.All)
            {
                if (!string.IsNullOrEmpty(Args.ScriptFileName))
                    return new ValidationResult("Command 'All' is not compatible with --script; the command must be more specific when using a specified configuration file.");

                if (!string.IsNullOrEmpty(Args.ConfigFileName))
                    return new ValidationResult("Command 'All' is not compatible with --config; the command must be more specific when using a specified configuration file.");
            }
            else
            {
                var vr = CheckCommandIsSupported(cmd, CommandType.Entity, IsEntitySupported);
                vr ??= CheckCommandIsSupported(cmd, CommandType.RefData, IsRefDataSupported);
                vr ??= CheckCommandIsSupported(cmd, CommandType.DataModel, IsDataModelSupported);
                vr ??= CheckCommandIsSupported(cmd, CommandType.Database, IsDatabaseSupported);
                if (vr != null)
                    return vr;
            }

            Args.ValidateCompanyAndAppName();

            return ValidationResult.Success;
        }

        /// <summary>
        /// Check command is supported.
        /// </summary>
        private static ValidationResult? CheckCommandIsSupported(CommandType act, CommandType exp, bool isSupported) => act == exp && !isSupported ? new ValidationResult($"Command '{act}' is not supported.") : null;

        /// <inheritdoc/>
        protected override async Task<CodeGenStatistics> OnCodeGenerationAsync()
        {
            OnWriteMasthead();
            OnWriteHeader();
            
            var cmd = _cmdArg!.ParsedValue;
            var exedir = GetBaseExeDirectory();

            var company = Args.GetCompany(false);
            var appName = Args.GetAppName(false);
            if (company == null || appName == null)
                throw new CodeGenException($"Parameters '{CompanyParamName}' and {AppNameParamName}  must be specified.");

            var count = 0;
            var stats = new CodeGenStatistics();
            if (IsDatabaseSupported && cmd.HasFlag(CommandType.Database))
                stats.Add(await ExecuteCodeGenerationAsync(_databaseScript, CodeGenFileManager.GetConfigFilename(exedir, CommandType.Database, company, appName), count++).ConfigureAwait(false));

            if (IsRefDataSupported && cmd.HasFlag(CommandType.RefData))
                stats.Add(await ExecuteCodeGenerationAsync(_refDataScript, CodeGenFileManager.GetConfigFilename(exedir, CommandType.RefData, company, appName), count++).ConfigureAwait(false));

            if (IsEntitySupported && cmd.HasFlag(CommandType.Entity))
                stats.Add(await ExecuteCodeGenerationAsync(_entityScript, CodeGenFileManager.GetConfigFilename(exedir, CommandType.Entity, company, appName), count++).ConfigureAwait(false));

            if (IsDataModelSupported && cmd.HasFlag(CommandType.DataModel))
                stats.Add(await ExecuteCodeGenerationAsync(_dataModelScript, CodeGenFileManager.GetConfigFilename(exedir, CommandType.DataModel, company, appName), count++).ConfigureAwait(false));

            if (cmd.HasFlag(CommandType.Clean))
                ExecuteClean();

            if (cmd.HasFlag(CommandType.Count))
                ExecuteCount();

            if (count > 1)
            {
                Args.Logger?.LogInformation("{Content}", new string('-', 80));
                Args.Logger?.LogInformation("{Content}", "");
                Args.Logger?.LogInformation("{Content}", $"{AppName} OVERALL. {stats.ToSummaryString()}");
                Args.Logger?.LogInformation("{Content}", "");
            }

            return stats;
        }

        /// <summary>
        /// Execute the selection code-generation.
        /// </summary>
        private async Task<CodeGenStatistics> ExecuteCodeGenerationAsync(string scriptName, string configName, int count)
        {
            // Update the files.
            var args = new CodeGeneratorArgs();
            args.CopyFrom(Args);
            args.ScriptFileName ??= scriptName;
            args.ConfigFileName ??= configName;

            if (count > 0)
            {
                args.Logger?.LogInformation("{Content}", new string('-', 80));
                args.Logger?.LogInformation("{Content}", "");
            }

            OnWriteArgs(args);

            // Execute the code-generation.
            var stats = await ExecuteCodeGenerationAsync(args).ConfigureAwait(false);

            // Write results.
            OnWriteFooter(stats);
            return stats;
        }

        /// <summary>
        /// Executes the code generation.
        /// </summary>
        /// <param name="args">The <see cref="CodeGeneratorArgs"/>.</param>
        /// <returns>The <see cref="CodeGenStatistics"/>.</returns>
        public static async Task<CodeGenStatistics> ExecuteCodeGenerationAsync(CodeGeneratorArgsBase args)
        {
            var cg = await OnRamp.CodeGenerator.CreateAsync<CodeGenerator>(args).ConfigureAwait(false);
            var fi = new FileInfo(args.ConfigFileName ?? throw new CodeGenException("Configuration file not specified."));
            return await cg.GenerateAsync(fi.FullName).ConfigureAwait(false);
        }

        /// <summary>
        /// Executes the clean.
        /// </summary>
        private void ExecuteClean()
        {
            if (Args.OutputDirectory == null)
                return;

            var exclude = Args.GetParameter<string?>("exclude")?.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) ?? [];

            Args.Logger?.LogInformation("{Content}", $"Cleaning: {Args.OutputDirectory.FullName}");
            Args.Logger?.LogInformation("{Content}", $"Exclude:  {string.Join(", ", exclude)}");
            Args.Logger?.LogInformation("{Content}", string.Empty);


            // Use the count logic to detemine all paths with specified exclusions.
            var sw = Stopwatch.StartNew();
            var dcs = new DirectoryCountStatistics(Args.OutputDirectory, exclude);
            CountDirectoryAndItsChildren(dcs);
            dcs?.Clean(Args.Logger!);

            sw.Stop();
            Args.Logger?.LogInformation("{Content}", string.Empty);
            Args.Logger?.LogInformation("{Content}", $"{AppName} Complete. [{sw.Elapsed.TotalMilliseconds}ms, Files: {dcs?.GeneratedTotalFileCount ?? 0}]");
            Args.Logger?.LogInformation("{Content}", string.Empty);
        }

        /// <summary>
        /// Executes the count.
        /// </summary>
        private void ExecuteCount()
        {
            if (Args.OutputDirectory == null)
                return;

            var exclude = Args.GetParameter<string?>("exclude")?.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) ?? [];

            Args.Logger?.LogInformation("{Content}", $"Counting: {Args.OutputDirectory.FullName}");
            Args.Logger?.LogInformation("{Content}", $"Include:  {string.Join(", ", _countExtensions)}");
            Args.Logger?.LogInformation("{Content}", $"Exclude:  {string.Join(", ", exclude)}");
            Args.Logger?.LogInformation("{Content}", string.Empty);

            var sw = Stopwatch.StartNew();
            var dcs = new DirectoryCountStatistics(Args.OutputDirectory, exclude);
            CountDirectoryAndItsChildren(dcs);

            var columnLength = Math.Max(dcs.TotalLineCount.ToString().Length, 5);
            dcs.Write(Args.Logger!, columnLength, 0);

            Args.Logger?.LogInformation("{Content}", string.Empty);
            Args.Logger?.LogInformation("{Content}", $"{AppName} Complete. [{sw.Elapsed.TotalMilliseconds}ms]");
            Args.Logger?.LogInformation("{Content}", string.Empty);
        }

        /// <summary>
        /// Count the directory and its children (recursive).
        /// </summary>
        private static void CountDirectoryAndItsChildren(DirectoryCountStatistics dcs)
        {
            foreach (var di in dcs.Directory.EnumerateDirectories())
            {
                if (di.Name.Equals("obj", StringComparison.InvariantCultureIgnoreCase) || di.Name.Equals("bin", StringComparison.InvariantCultureIgnoreCase))
                    continue;

                if (dcs.Exclude.Any(x => di.Name.Contains(x, StringComparison.InvariantCultureIgnoreCase)))
                    continue;

                CountDirectoryAndItsChildren(dcs.AddChildDirectory(di));
            }

            foreach (var fi in dcs.Directory.EnumerateFiles())
            {
                if (!_countExtensions.Contains(fi.Extension, StringComparer.OrdinalIgnoreCase))
                   continue;

                using var sr = fi.OpenText();
                while (sr.ReadLine() is not null)
                {
                    dcs.IncrementLineCount();
                }

                dcs.IncrementFileCount();
            }
        }

        /// <summary>
        /// Provides <see cref="DirectoryInfo"/> count statistics.
        /// </summary>
        internal class DirectoryCountStatistics
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DirectoryCountStatistics"/> class.
            /// </summary>
            public DirectoryCountStatistics(DirectoryInfo directory, string[] exclude)
            {
                Directory = directory;
                if (directory.Name == "Generated")
                    IsGenerated = true;

                Exclude = exclude ?? [];
            }

            /// <summary>
            /// Gets the <see cref="DirectoryInfo"/>.
            /// </summary>
            public DirectoryInfo Directory { get; }

            /// <summary>
            /// Gets the directory/path names to exclude.
            /// </summary>
            public string[] Exclude { get; private set; }

            /// <summary>
            /// Gets the file count.
            /// </summary>
            public int FileCount { get; private set; }

            /// <summary>
            /// Gets the total file count including children.
            /// </summary>
            public int TotalFileCount => FileCount + Children.Sum(x => x.TotalFileCount);

            /// <summary>
            /// Gets the generated file count.
            /// </summary>
            public int GeneratedFileCount { get; private set; }

            /// <summary>
            /// Gets the total generated file count including children.
            /// </summary>
            public int GeneratedTotalFileCount => GeneratedFileCount + Children.Sum(x => x.GeneratedTotalFileCount);

            /// <summary>
            /// Gets the line count;
            /// </summary>
            public int LineCount { get; private set; }

            /// <summary>
            /// Gets the total line count including children.
            /// </summary>
            public int TotalLineCount => LineCount + Children.Sum(x => x.TotalLineCount);

            /// <summary>
            /// Gets the generated line count.
            /// </summary>
            public int GeneratedLineCount { get; private set; }

            /// <summary>
            /// Gets the total line count including children.
            /// </summary>
            public int GeneratedTotalLineCount => GeneratedLineCount + Children.Sum(x => x.GeneratedTotalLineCount);

            /// <summary>
            /// Indicates whether the contents of the directory are generated.
            /// </summary>
            public bool IsGenerated { get; private set; }

            /// <summary>
            /// Gets the child <see cref="DirectoryCountStatistics"/> instances.
            /// </summary>
            public List<DirectoryCountStatistics> Children { get; } = [];

            /// <summary>
            /// Increments the file count.
            /// </summary>
            public void IncrementFileCount()
            {
                FileCount++;
                if (IsGenerated)
                    GeneratedFileCount++;
            }

            /// <summary>
            /// Increments the line count.
            /// </summary>
            public void IncrementLineCount()
            {
                LineCount++;
                if (IsGenerated)
                    GeneratedLineCount++;
            }

            /// <summary>
            /// Adds a child <see cref="DirectoryCountStatistics"/> instance.
            /// </summary>
            public DirectoryCountStatistics AddChildDirectory(DirectoryInfo di)
            {
                var dcs = new DirectoryCountStatistics(di, Exclude);
                if (IsGenerated)
                    dcs.IsGenerated = true;

                Children.Add(dcs);
                return dcs;
            }

            /// <summary>
            /// Write the count statistics.
            /// </summary>
            /// <param name="logger">The <see cref="ILogger"/>.</param>
            /// <param name="columnLength">The maximum column length.</param>
            /// <param name="indent">The indent size to show hierarchy.</param>
            public void Write(ILogger logger, int columnLength, int indent = 0)
            {
                if (indent == 0)
                {
                    var hdrAll = string.Format("{0, " + columnLength + "}", "All");
                    var hdrGen = string.Format("{0, " + (columnLength + 5) + "}", "Generated");
                    var hdrfiles = string.Format("{0, " + columnLength + "}", "Files");
                    var hdrlines = string.Format("{0, " + columnLength + "}", "Lines");

                    logger.LogInformation("{Content}", $"{hdrAll} | {hdrAll} | {hdrGen} | {hdrGen} | Path/");
                    logger.LogInformation("{Content}", $"{hdrfiles} | {hdrlines} | {hdrfiles} Perc | {hdrlines} Perc | Directory");
                    logger.LogInformation("{Content}", new string('-', 75));
                }

                var totfiles = string.Format("{0, " + columnLength + "}", TotalFileCount);
                var totlines = string.Format("{0, " + columnLength + "}", TotalLineCount);
                var totgenFiles = string.Format("{0, " + columnLength + "}", GeneratedTotalFileCount);
                var totgenFilesPerc = string.Format("{0, " + 3 + "}", GeneratedTotalFileCount == 0 ? 0 : Math.Round((double)GeneratedTotalFileCount / (double)TotalFileCount * 100.0, 0));
                var totgenLines = string.Format("{0, " + columnLength + "}", GeneratedTotalLineCount);
                var totgenLinesPerc = string.Format("{0, " + 3 + "}", GeneratedTotalLineCount == 0 ? 0 : Math.Round((double)GeneratedTotalLineCount / (double)TotalLineCount * 100.0, 0));

                logger.LogInformation("{Content}", $"{totfiles}   {totlines}   {totgenFiles} {totgenFilesPerc}%   {totgenLines} {totgenLinesPerc}%   {new string(' ', indent * 2)}{Directory.FullName}");
                    
                foreach (var dcs in Children)
                {
                    if (dcs.TotalFileCount > 0)
                        dcs.Write(logger, columnLength, indent + 1);
                }
            }

            /// <summary>
            /// Cleans (deletes) all <see cref="IsGenerated"/> directories.
            /// </summary>
            /// <param name="logger">The <see cref="ILogger"/></param>
            public void Clean(ILogger logger)
            {
                // Where generated then delete.
                if (IsGenerated)
                {
                    logger.LogWarning("  Deleted: {Directory} [{FileCount} files]", Directory.FullName, TotalFileCount);
                    Directory.Delete(true);
                    return;
                }

                // Where not generated then clean children.
                foreach (var dcs in Children)
                {
                    dcs.Clean(logger);
                }
            }
        }
    }
}
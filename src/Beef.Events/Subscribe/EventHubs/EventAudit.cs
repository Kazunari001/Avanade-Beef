﻿// Copyright (c) Avanade. Licensed under the MIT License. See https://github.com/Avanade/Beef

using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Beef.Events.Subscribe.EventHubs
{
    /// <summary>
    /// Represents an Event Audit <see cref="TableEntity"/>.
    /// </summary>
    public class EventAudit : TableEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventAudit"/> class.
        /// </summary>
        public EventAudit() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventAudit"/> class with a specified <paramref name="partitionKey"/> and <paramref name="rowKey"/>.
        /// </summary>
        /// <param name="partitionKey">The <see cref="TableEntity.PartitionKey"/>.</param>
        /// <param name="rowKey">The <see cref="TableEntity.RowKey"/>.</param>
        public EventAudit(string partitionKey, string rowKey) : base(partitionKey, rowKey) { }

        /// <summary>
        /// Gets or sets the offset of the data relative to the Event Hub partition stream.
        /// </summary>
        public string? Offset { get; set; }

        /// <summary>
        /// Gets or sets the logical sequence number of the event within the partition stream of the Event Hub.
        /// </summary>
        public long SequenceNumber { get; set; }

        /// <summary>
        /// Indicates whether to skip the poison message and continue processing the next.
        /// </summary>
        public bool SkipMessage { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the enqueue time in UTC.
        /// </summary>
        public DateTime EnqueuedTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time when initially poisoned in UTC.
        /// </summary>
        public DateTime? PoisonedTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the message was skipped in UTC.
        /// </summary>
        public DateTime? SkippedTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets the number of retries.
        /// </summary>
        public int Retries { get; set; }

        /// <summary>
        /// Gets or sets the event subject.
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// Gets or sets the event action.
        /// </summary>
        public string? Action { get; set; }

        /// <summary>
        /// Gets or sets the status (see <see cref="Result.Status"/>).
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the reason (see <see cref="Result.Reason"/>).
        /// </summary>
        public string? Reason { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Microsoft.Azure.EventHubs.EventData.Body"/> content as a <see cref="string"/>.
        /// </summary>
        public string? Body { get; set; }

        /// <summary>
        /// Gets or sets the exception (see <see cref="Result.Exception"/>).
        /// </summary>
        public string? Exception { get; set; }
    }
}
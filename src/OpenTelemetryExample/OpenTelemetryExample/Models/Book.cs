﻿namespace OpenTelemetryExample.Models
{
    public record Book
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public required string Description { get; set; }
    }
}

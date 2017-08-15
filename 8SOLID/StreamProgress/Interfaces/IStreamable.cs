﻿namespace StreamProgress.Interfaces
{
    public interface IStreamable
    {
        int Length { get; }

        int BytesSent { get; }
    }
}
﻿using System;
using SecurityDoor.Interfaces;

namespace SecurityDoor.Models
{
    public class ScannerUI : ISecurityUI
    {
        public string RequestKeyCard()
        {
            Console.WriteLine("Slide your key card");
            return Console.ReadLine();
        }

        public int RequestPinCode()
        {
            Console.WriteLine("Enter your pin code:");
            return int.Parse(Console.ReadLine());
        }
    }
}
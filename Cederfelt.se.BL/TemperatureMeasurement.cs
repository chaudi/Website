﻿using System;

namespace Cederfelt.se.BL
{
    public class TemperatureMeasurement
    {
        public int Id { get; set; }
        public double Degrees { get; set; }
        public double Humidity { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

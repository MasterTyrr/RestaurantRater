﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRATER.Models
{
    public class Restaurant
    {
        public int ResaurantID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
    }

    public class RestaurantDBContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
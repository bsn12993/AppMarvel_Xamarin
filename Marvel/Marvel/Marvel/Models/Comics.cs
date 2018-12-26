﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Marvel.Models
{
    public class Comics
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public List<Item> items { get; set; }
        public int returned { get; set; }
    }
}

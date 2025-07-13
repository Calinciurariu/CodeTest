using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Models

    {
        public class Song
        {
            public required string Title { get; set; }
            public required string Artist { get; set; }
            public required string AlbumArt { get; set; }
        }
    }

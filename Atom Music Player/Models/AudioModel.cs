using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atom_Music_Player.Models
{
   public class AudioModel
    {
       // public File AudioFile {  }
        public String Title { get; set; }
        public String Artist { get; set; }
        public String Album { get; set; }
        public long Year { get; set; }
        public long Duration { get; set; }
    }
}

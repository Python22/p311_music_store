using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p311_music_store
{
    internal class Records
    {
        public int id { get; set;}
        public string name { get; set; }
        public List<Groups> groups { get; set; }
        public int quantity_on_store { get; set; }
        public int price { get; set; }
        public List<Music> musics { get; set; }
    }

    class Groups
    {
        public int id { get; set; }
        public string name { get; set; }
        public string people { get; set; }
    }
    class Genres
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    class Albums
    {
        public int id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public Groups group { get; set; }
    }
    class Music
    {
        public int id { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public Groups group { get; set; }
        public Albums album { get; set; }
        public List<Genres> genres { get; set; }
    }

}

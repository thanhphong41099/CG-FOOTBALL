namespace VLeague
{
    public class Player
    {
        private string _name;
        private string _shortname;
        private string _number;
        private string _pos;
        private string _image;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string ShortName
        {
            get { return _shortname; }
            set { _shortname = value; }
        }
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
        public string Position
        {
            get { return _pos; }
            set { _pos = value; }
        }
    }
}

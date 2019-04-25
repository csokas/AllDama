namespace DamaShared
{
    public class PuppetModel
    {
        private SimpleOrDama type = SimpleOrDama.Simple;
        public SimpleOrDama Typ
        {
           
            get { return type; }
            set { type = value; }
        }

        private Colour colour;
        public Colour Color
        {
            get { return colour; }
            set { colour = value; }
        }

        protected PuppetModel() { }//singleton miatt

        public PuppetModel(Colour colour)
        {
            this.type = SimpleOrDama.Simple;
            this.colour = colour;
        }

        public PuppetModel(Colour colour, SimpleOrDama type)
        {
            this.type = type;
            this.colour = colour;
        }

        public enum Colour { Red, Blue };

        public enum SimpleOrDama { Simple, Dama };
    }
}

using System;

namespace DamaShared
{
    public sealed class SingletonPuppets : PuppetModel
    {
        private static PuppetModel[,] puppets = new PuppetModel[8, 8];

        private SingletonPuppets() { }
        
        public static Lazy<SingletonPuppets> instance { get; } =
            new Lazy<SingletonPuppets>(() => new SingletonPuppets(), true);

        public PuppetModel[,] GetInstance()
        {
            return puppets;
        }

    }
}

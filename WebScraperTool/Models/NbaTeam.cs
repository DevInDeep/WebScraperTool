namespace WebScraperTool
{
    public class NbaTeam
    {
        public string Name { get; } = string.Empty;
        public int Championships { get; }

        private NbaTeam(string name, int championships)
        {
            this.Name = name;
            this.Championships = championships;
        }

        public override string ToString() => $"{Name} {Championships}";

        public static NbaTeam Create() => new NbaTeam(string.Empty, 0);
        public static NbaTeam Create(string name, int championships) => new NbaTeam(name, championships);
    }
}

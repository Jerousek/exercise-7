using System.Text;
using System.Text.Json;

namespace ChampionsLeagueLibrary
{
    public class PlayersFileSerializerDeserializer
    {
        readonly IPlayerSavableLoadable players;
        readonly string file;

        public PlayersFileSerializerDeserializer(IPlayerSavableLoadable players, string file)
        {
            this.players = players;
            this.file = file;
        }

        public void Save()
        {
            Player[] poleHracu = players.Save();
            using (StreamWriter writer = new StreamWriter(new FileStream(file, FileMode.OpenOrCreate), Encoding.UTF8))
            {
                foreach (var player in poleHracu)
                {
                    writer.WriteLine(Serialize(player));
                }
            }

        }

        public void Load()
        {
            Player[] poleHracu = new Player[0];
            using (var reader = new StreamReader(file))
            {
                while(!reader.EndOfStream)
                {
                    Array.Resize(ref poleHracu, poleHracu.Length+1);
                    poleHracu[poleHracu.Length - 1] = Deserialize(reader.ReadLine());
                }
            }
            players.Load(poleHracu);
        }

        private static string Serialize(Player p)
        {
            return JsonSerializer.Serialize(p);
        }

        private static Player Deserialize(string s)
        {
            try
            {
                return JsonSerializer.Deserialize<Player>(s);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

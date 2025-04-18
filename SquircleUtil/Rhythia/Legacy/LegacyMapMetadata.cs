

namespace SquircleUtil.Rhythia.Legacy
{
    public class LegacyMapMetadata : IMapMetadata
    {
        public string ID { get; set; } = string.Empty;

        public bool HasAudio { get; set; }

        public bool HasCover { get; set; }

        public bool HasVideo { get; set; }

        public bool HasColorSet { get; set; }

        public string AudioExtension { get; set; } = string.Empty;

        public string Artist { get; set; } = string.Empty;

        public string RomanizedArtist { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string RomanizedTitle { get; set; } = string.Empty;

        public List<string> Mappers { get; set; } = [];

        public List<int> MappersIds { get; set; } = [];

        public int NoteCount { get; set; } = 0;

        public int Difficulty { get; set; } = 0;

        public string DifficultyName { get; set; } = string.Empty;

        IEnumerable<string> IMapMetadata.Mappers => Mappers;
    }
}

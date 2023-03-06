
namespace DrWizardry.Models
{
    public class Vocab
    {
        public int VocabId { get; set; }
        public string Word { get; set; }
        public string Definition { get; set; }
        public string Example { get; set; }
        public DateTime Date { get; set; }
        public List<Synonym> Synonyms { get; set; }
        public int Difficulty_lvl { get; set; }
        public int Priority { get; set; }
        public int UserID { get; set; }
    }
}

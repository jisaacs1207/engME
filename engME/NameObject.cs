using System.ComponentModel;
using System.Runtime.CompilerServices;
using engME.Annotations;

namespace engME
{
    public class NameObject : INotifyPropertyChanged
    {
        public bool Favorited { get; set; }
        public string Name { get; set; }
        public bool Suggested { get; set; }
        public bool Popular { get; set; }
        public string Gender { get; set; }
        public short Personality { get; set; }
        public short Decade { get; set; }
        public string Origin { get; set; }
        public string Diminutives { get; set; }
        public string ShortMeaning { get; set; }
        public string LongMeaning { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
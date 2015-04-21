
namespace _2._1._6
{
    class DevelopersTeam
    {
        private Developer[] _group { get; set; }

        public DevelopersTeam(Developer developers)
        {
            _group[0] = developers;
        }

        public DevelopersTeam(Developer[] people)
        {
            _group = people;
        }

        public Developer this[int x]
        {
            get
            {
                return _group[x];
            }
            set
            {
                _group[x] = value;
            }
        }
    }
}

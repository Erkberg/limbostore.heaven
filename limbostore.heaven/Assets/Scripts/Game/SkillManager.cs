namespace Game
{
    public class SkillManager
    {
        private bool[] availableSkills;

        public SkillManager()
        {
            availableSkills = new bool[System.Enum.GetNames(typeof(SkillType)).Length];
        }

        public void AddSkill(SkillType skillType)
        {
            availableSkills[(int) skillType] = true;
        }

        public bool CanDo(SkillType skillType)
        {
            return availableSkills[(int) skillType];
        }
    }
}
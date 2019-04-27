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
            if(skillType == SkillType.None)
            {
                return true;
            }
            else
            {
                return availableSkills[(int)skillType];
            }            
        }
    }
}
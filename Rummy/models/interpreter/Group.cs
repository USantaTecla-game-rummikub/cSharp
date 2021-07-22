using Rummy.types;

namespace Rummy.models.interpreter
{
    public class Group : Expression
    {
        private string group;

        public Group(string group)
        {
            this.group = group;
        }
       
        public override void interpret(IPlayerCommand player) {
            if (this.group != null && this.group != "" && !player.existGroup(this.group)) {
                this.error = ErrorMessage.WRONG_GROUP;
            } 
        }

        public string getGroup()
        {
            return this.group;
        }

        public int toInt()
        {
            return int.Parse(group);
        }
    }
}
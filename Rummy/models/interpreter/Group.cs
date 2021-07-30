using Rummy.types;

namespace Rummy.models.interpreter
{
    public class Group : Expression
    {
        public static string NEW = "";
        private string group;

        public Group(string group)
        {
            this.group = group;
        }
       
        public Group()
        {
            this.group = NEW;
        }

        public override void interpret(IPlayerCommand player) {
            if (this.group != null && this.group != NEW && !player.existGroup(this.group)) {
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
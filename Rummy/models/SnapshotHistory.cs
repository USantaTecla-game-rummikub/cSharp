using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models
{
    public class SnapshotHistory
    {
        private List<SnapShot> snapshots;
        private int pointer;
        private Turn turn;
        private Player player;

        public SnapshotHistory(Turn turn)
        {
            this.snapshots = new List<SnapShot>();
            this.pointer = 0;
            this.turn = turn;
            this.player = null;
        }

        private bool canDoneBackup(Player player)
        {            
            return player.getLastAction() != ActionType.UNDO && player.getLastAction() != ActionType.REDO;
        }

        public void backup(Player player)
        {
            if (this.canDoneBackup(player))
            {
                this.snapshots.Add(this.turn.save());
                this.pointer++;
            }
        }

        public void restoreAccordingAction(Player player)
        {
            if (player.getLastAction() == ActionType.UNDO)
            {
                turn.restore(this.undo());
            } else if (player.getLastAction() == ActionType.REDO)
            {
                turn.restore(this.redo());
            }
        }

        public SnapShot undo()
        {
            if (this.pointer > 0)
            {
                this.pointer--;
                return this.snapshots[this.pointer];
            } else
            {
                return this.snapshots[0];
            }
        }

        public SnapShot redo()
        {
            if (this.pointer < this.snapshots.Count - 1)
            {
                this.pointer++;
                return this.snapshots[this.pointer];
            } else
            {
                return this.snapshots[this.snapshots.Count - 1];
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ModernLangToolsApp
{
    public class JediCouncil
    {
        List<Jedi> members = new List<Jedi>();
        public event Notification CouncilChanged;
        public void Add(Jedi newJedi) 
        {
            members.Add(newJedi);
            if (CouncilChanged != null) 
                CouncilChanged("Új taggal bővültünk");
        }
        public void Remove()
        {
            // Eltávolítja a lista utolsó elemét
            members.RemoveAt(members.Count - 1);
            if (CouncilChanged != null)
            {
                if (members.Count > 0)
                    CouncilChanged("Zavart érzek az erőben");
                else CouncilChanged("A tanács elesett!");
            }
        }

        public List<Jedi> GetBeginners() => members.FindAll(SmallJedi);

        //segédfüggvény, ami alapján dönt a FindAll
        private bool SmallJedi(Jedi obj)
        {
            return 300 > obj.MidiChlorianCount;
        }
    }
}

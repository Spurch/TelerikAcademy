namespace MySolution.Model
{
    using System;
    using System.Collections.Generic;

   public class MyOtherClass
    {
       public int MyOtherClassId { get; set; }

        public string Name { get; set; }

        public int SomeValue { get; set; }

        public int PropId { get; set; }

        public virtual MyProperty Prop { get; set; }
    }
}

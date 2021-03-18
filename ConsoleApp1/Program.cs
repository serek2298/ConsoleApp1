using System;
using System.Collections.Generic;




namespace ConsoleApp1
{
    public class Item
    {
        public float Value;
        public int Weight;

        public Item(float val, int w)
        {
            this.Value = val;
            this.Weight = w;
        }
        public Item()
        {
            this.Value = 1;
            this.Weight = 1;
        }
       
    }

    public class Backpack
    {
        public int maxCapacity;
        public int currentCapacity;
        public List<Item> Items;

        public Backpack(int cap)
        {
            this.maxCapacity = cap;
            this.Items = new List<Item>();
            this.currentCapacity = 0;

        }
        public void Add(Item newitem)
        {
            if (this.currentCapacity + newitem.Weight <= maxCapacity) {
                this.Items.Add(newitem);
                this.currentCapacity += newitem.Weight;
                    }
        }

        public void FindBestAnswear(List<Item> list)
        {
            List < Tuple<Item,float> > t = new List<Tuple<Item, float>>();
            foreach (Item x in list) {
                t.Add(new Tuple<Item, float>(x, x.Value / x.Weight));
            }
            
            t.Sort((x,y)=>x.Item2.CompareTo(y.Item2));
            t.Reverse();
            foreach( Tuple<Item,float> k in t)
            {
                this.Add(k.Item1);               
            }
        }
    }

    
   
    class Program
    {
        static void Main(string[] args)
        {

            Backpack bag = new Backpack(100);
            RandomNumberGenerator rng = new RandomNumberGenerator(5);
            List<Item> Items = new List<Item>();
            for(int i = 0; i < 10; i++)
            {
                Items.Add(new Item(rng.nextFloat(1, 29),rng.nextInt(1,29)));
            }
            bag.FindBestAnswear(Items);
            int c = 0;


            System.Console.WriteLine("Zawartość plecaka:");
            foreach (Item i in bag.Items)
            {
                c++;
                System.Console.WriteLine("Przedmiot"+ c +": Weight: "+i.Weight+" Value: "+i.Value );
            }
            

        }
    }
}

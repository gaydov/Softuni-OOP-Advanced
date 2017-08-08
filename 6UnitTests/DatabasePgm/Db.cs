using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DatabasePgm
{
    public class Db
    {
        private const int ArrayCapacity = 16;

        private readonly int[] items;
        private int currentIndex;

        public Db(params int[] inputItems)
        {
            this.items = new int[ArrayCapacity];
            this.currentIndex = 0;

            if (inputItems.Length > ArrayCapacity)
            {
                throw new InvalidOperationException($"Input items are more than the capacity of the collection - {ArrayCapacity}");
            }

            foreach (int inputItem in inputItems)
            {
                this.items[this.currentIndex] = inputItem;
                this.currentIndex++;
            }
        }

        // Indexer for the database
        public int this[int i]
        {
            get { return this.items[i]; }
        }

        public void Add(int element)
        {
            if (this.currentIndex == ArrayCapacity)
            {
                throw new InvalidOperationException("The database is already full.");
            }

            this.items[this.currentIndex] = element;
            this.currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("The database is already empty.");
            }

            this.items[this.currentIndex - 1] = 0;
            this.currentIndex--;
        }

        public int[] Fetch()
        {
            return this.items.Take(this.currentIndex).ToArray();
        }
    }
}
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    private List<Book> books;

    public Library(params Book[] books)
    {
        this.books = new List<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private int currentIndex;
        private IList<Book> books;

        public LibraryIterator(IList<Book> books)
        {
            this.books = new List<Book>(books);
            this.Reset();
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            this.currentIndex++;
            return this.currentIndex < this.books.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }

        public Book Current
        {
            get { return this.books[this.currentIndex]; }
        }

        object IEnumerator.Current
        {
            get { return this.Current; }
        }
    }
}

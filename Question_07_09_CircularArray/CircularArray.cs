using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_07_09_CircularArray
{
    public class CircularArray<T> : IEnumerable<T>, IEnumerator<T>
    {
        int length;
        int headIndex;
        int enumeratorIndex;
        T[] baseArray;

        public CircularArray(int size)
        {
            if (size < 0) throw new ArgumentOutOfRangeException();
            length = size;

            baseArray = new T[size];

            headIndex = 0;
            enumeratorIndex = -1;
        }

        public T this[int index]
        {
            get
            {
                return baseArray[getActualPosition(index)];
            }
            set
            {
                baseArray[getActualPosition(index)] = value;
            }
        }

        public void shift(int shiftBy)
        {
            headIndex = (length - (shiftBy % length)) % length;
        }

        private int getActualPosition(int index)
        {           
            return (headIndex + index) % length;
        }

        #region IEnumerator
        T IEnumerator<T>.Current
        {
            get
            {
                return this[enumeratorIndex];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        bool IEnumerator.MoveNext()
        {
            enumeratorIndex++;
            if (enumeratorIndex >= length)
            {
                enumeratorIndex = -1;
                return false;
            }

            return true;
        }

        void IEnumerator.Reset()
        {
            enumeratorIndex = -1;
        }
        #endregion

        #region IEnumerable
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotSupportedException();
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CircularArray() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}

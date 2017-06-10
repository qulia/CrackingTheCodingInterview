using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Trie : IEnumerable<string>
    {
        public class TriePrefixEnumerator : IEnumerable<string>, IEnumerator<string>
        {
            public class PrefixNode
            {
                public PrefixNode(string prefix, Node node, int childIndex)
                {
                    Prefix = prefix;
                    Node = node;
                    ChildIndex = childIndex;
                }

                public string Prefix
                {
                    get;
                    set;
                }

                public Node Node
                {
                    get;
                    set;
                }

                public int ChildIndex
                {
                    get;
                    set;
                }
            }

            Trie trie;
            string prefix = string.Empty;
            System.Collections.Generic.Stack<PrefixNode> parents = new System.Collections.Generic.Stack<PrefixNode>();
            PrefixNode currentParent;
            
            public TriePrefixEnumerator(Trie trie)
            {
                this.trie = trie;
                parents.Push(new PrefixNode(string.Empty, trie.Root, 0));
            }

            public TriePrefixEnumerator(Trie trie, string prefix)
            {
                this.trie = trie;
                this.prefix = prefix;
                var node = trie.Root.FindPrefix(prefix);
                if (node != null)
                {
                    parents.Push(new PrefixNode(prefix, node, 0));
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotSupportedException();
            }

            IEnumerator<string> IEnumerable<string>.GetEnumerator()
            {
                return this;
            }

            object IEnumerator.Current
            {
                get
                {
                    throw new NotSupportedException();
                }
            }

            string IEnumerator<string>.Current
            {
                get
                {
                    StringBuilder value = new StringBuilder();
                    value.Append(currentParent.Prefix);
                    var child = currentParent.Node.Children.ElementAt(currentParent.ChildIndex);
                    Node currentNode = child.Value;
                    value = child.Key == char.MinValue ? value : value.Append(child.Key);
                    while(currentNode != null)
                    {
                        if (currentNode.Children.Count > 1)
                        {
                            currentParent.ChildIndex++;
                            parents.Push(currentParent);
                            currentParent = new PrefixNode(value.ToString(), currentNode, 0);
                            var pickedChild = currentParent.Node.Children.ElementAt(currentParent.ChildIndex);
                            value = pickedChild.Key == char.MinValue ? value : value.Append(pickedChild.Key);
                            currentNode = pickedChild.Value;
                        }
                        else if (currentNode.Children.Count == 1)
                        {
                            var pickedChild = currentNode.Children.ElementAt(0);
                            value = pickedChild.Key == char.MinValue ? value : value.Append(pickedChild.Key);
                            currentNode = pickedChild.Value;
                        }
                        else
                        {
                            return value.ToString();
                        }
                    }

                    return value.ToString();

                }
            }

            bool IEnumerator.MoveNext()
            {
                if (currentParent != null)
                {
                    currentParent.ChildIndex++;
                }

                while(currentParent == null || currentParent.ChildIndex >= currentParent.Node.Children.Count)
                {
                    try
                    {
                        currentParent = parents.Pop();
                     }
                    catch (InvalidOperationException)
                    {
                        return false;
                    }
                }
                
                return true;
            }

            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

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
            // ~TriePrefixEnumerator() {
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

        public class Node
        {
            public Node()
            {
                Children = new Dictionary<char, Node>();
                Data = char.MaxValue;
            }

            public Node(char data)
            {
                Data = data;
                Children = new Dictionary<char, Node>();
            }

            public char Data
            {
                get;
                set;
            }

            public Dictionary<char, Node> Children
            {
                get;
                private set;
            }

            internal void Insert(string prefix)
            {
                char currentChar;
                if (prefix.Length <= 0)
                {
                    currentChar = char.MinValue;
                    if (!Children.ContainsKey(currentChar))
                    {
                        Children.Add(currentChar, new Node(currentChar));
                    }
                    return;
                }

                currentChar = prefix[0];
                if (!Children.ContainsKey(currentChar))
                {
                    Children.Add(currentChar, new Node(currentChar));
                }

                Children[currentChar].Insert(prefix.Substring(1, prefix.Length - 1));
            }

            internal Node FindPrefix(string prefix)
            {
                if (prefix.Length <= 0)
                {
                    return this;
                }

                var currentChar = prefix[0];
                if (Children.ContainsKey(currentChar))
                {
                    return Children[currentChar].FindPrefix(prefix.Substring(1, prefix.Length - 1));
                }

                return null;
            }
        }

        public Trie()
        {
            Root = new Node();
        }

        public Node Root
        {
            get;
            set;
        }

        public void Insert(string newData)
        {
            Root.Insert(newData);
        }

        public IEnumerable<string> StartsWith(string prefix)
        {
            return new TriePrefixEnumerator(this, prefix);
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return new TriePrefixEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotSupportedException();
        }
    }
}

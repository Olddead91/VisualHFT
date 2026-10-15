namespace VisualHFT.Commons.Helpers
{
    /// <summary>
    /// Remembers the most recent ids it has accepted, up to a fixed capacity, so a caller can
    /// refuse an id it has already seen. Intended to be called once per item on a hot path.
    /// </summary>
    /// <remarks>
    /// The ring holds the ids in arrival order and the set answers "seen?" in O(1). Both are sized
    /// once in the constructor, and the oldest id is evicted before a new one is added, so the set
    /// never holds more than <c>capacity</c> ids and never grows: a call allocates nothing.
    /// </remarks>
    public sealed class RecentIdFilter
    {
        private readonly object _gate = new object();
        private readonly long[] _ring;
        private readonly HashSet<long> _ids;
        private int _next;
        private int _count;

        public RecentIdFilter(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Capacity must be positive.");

            _ring = new long[capacity];
            _ids = new HashSet<long>(capacity);
        }

        /// <summary>
        /// Returns true when <paramref name="id"/> was not seen within the window and records it;
        /// returns false when it was seen.
        /// </summary>
        public bool TryRecord(long id)
        {
            // Normally one caller per instance, so the lock is uncontended; it keeps the ring and the
            // set consistent if two threads ever share an instance.
            lock (_gate)
            {
                if (_ids.Contains(id))
                    return false;

                if (_count == _ring.Length)
                    _ids.Remove(_ring[_next]);
                else
                    _count++;

                _ring[_next] = id;
                _ids.Add(id);
                _next = _next + 1 == _ring.Length ? 0 : _next + 1;
                return true;
            }
        }
    }
}

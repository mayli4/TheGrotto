namespace TheGrotto.Core {
    internal interface ITileAccessor : IEnumerator<Tile>{
        public int Index { get; set; }
        public Point CurrentCoords { get; }
        bool MoveNext();
    }
}

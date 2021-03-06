﻿namespace funclib.Collections
{
    public interface IChunkedSeq :
        ISeq,
        ISequential
    {
        IChunked ChunkedFirst();
        ISeq ChunkedNext();
        ISeq ChunkedMore();
    }
}

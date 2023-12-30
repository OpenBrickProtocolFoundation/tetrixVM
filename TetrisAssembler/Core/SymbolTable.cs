﻿using System.Collections;
using System.Text;
using TetrisAssembler.Core.Values;

namespace TetrisAssembler.Core {
    public class SymbolTable : IEnumerable<SymbolTable.Entry> {
        public List<Entry> entries;

        public SymbolTable() {
            entries = new();
        }

        public void Add(long offset, IValue reference, Trace trace) {
            entries.Add(new()
            {
                Offset = offset,
                Reference = reference,
                Trace = trace
            });
        }

        public IEnumerator<Entry> GetEnumerator() {
            return entries.GetEnumerator();
        }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();

            foreach (Entry entry in entries) {
                builder.AppendFormat("{0:X8}: {1}\n", entry.Offset, entry.Reference);
            }

            return builder.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public class Entry {
            public long Offset { get; set; }
            public IValue Reference { get; set; }
            public Trace Trace { get; internal set; }
        }
    }
}

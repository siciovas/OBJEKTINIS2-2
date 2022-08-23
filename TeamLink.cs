using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD2
{
    public sealed class TeamLink
    {
        private sealed class TeamNode
        { 
            public Team Data { get; set; }
            public TeamNode Link { get; set; }
            public TeamNode(Team value, TeamNode address)
            {
                Data = value;
                Link = address;
            }
        }

        private TeamNode Head;
        private TeamNode Current;
        private TeamNode Tail;

        public TeamLink()
        {
            this.Head = null;
            this.Current = null;
            this.Tail = null;
        }

        public void Start()
        {
            Current = Head;
        }

        public void Next()
        {
            Current = Current.Link;
        }

        public bool Is()
        {
            return Current != null;
        }

        public Team Get()
        {
            if(Current == null)
            {
                return null;
            }

            return Current.Data;
        }

        public void Add(Team data)
        {
            Head = new TeamNode(data, Head);
        }

        public void Delete()
        {
            while(Head != null)
            {
                Current = Head;
                Head = Head.Link;
                Current = null;
            }
            Tail = Current = Head;
        }
    }
}
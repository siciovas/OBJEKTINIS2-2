using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD2
{
    public sealed class PlayerLink
    {
        private sealed class PlayerNode
        { 
            public Player Data { get; set; }
            public PlayerNode Link { get; set; }
            public PlayerNode(Player value, PlayerNode address)
            {
                this.Data = value;
                this.Link = address;
            }
        }

        private PlayerNode Head;
        private PlayerNode Current;
        private PlayerNode Tail;

        public PlayerLink()
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

        public Player Get()
        {
            return Current.Data;
        }

        public void Add(Player data)
        {
            Head = new PlayerNode(data, Head);
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

        public void Sort()
        {
            for(PlayerNode d1 = Head; d1.Link != null; d1 = d1.Link)
            {
                PlayerNode max = d1;
                
                for(PlayerNode d2 = d1; d2 != null; d2 = d2.Link)
                {
                    if(d2.Data < d1.Data)
                    {
                        max = d2;
                    }
                }

                Player mod = d1.Data;
                d1.Data = max.Data;
                max.Data = mod;
            }
        }

    }
}
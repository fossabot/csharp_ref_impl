// -*- mode: csharp; tab-width: 4; indent-tabs-mode: nil; c-basic-offset: 4 -*-
//
// Copyright (C) 2012-2015 Marco Craveiro <marco.craveiro@gmail.com>
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
// MA 02110-1301, USA.
//
using System;
using System.Collections;
using System.Collections.Generic;

namespace dogen.test_models.LAMModel
{
    /// <summary>
    /// Generates sequences of Builtins.
    /// </summary>
    public static class BuiltinsSequenceGenerator
    {
        static internal void Populate(Builtins value, uint position)
        {
            value.Prop0 = AssistantSequenceGenerator.CreateChar(position + 0);
            value.Prop1 = AssistantSequenceGenerator.CreateByte(position + 1);
            value.Prop2 = AssistantSequenceGenerator.CreateShortByte(position + 2);
            value.Prop3 = AssistantSequenceGenerator.CreateShort(position + 3);
            value.Prop4 = AssistantSequenceGenerator.CreateInt(position + 4);
            value.Prop5 = AssistantSequenceGenerator.CreateLong(position + 5);
            value.Prop6 = AssistantSequenceGenerator.CreateInt(position + 6);
            value.Prop7 = AssistantSequenceGenerator.CreateFloat(position + 7);
            value.Prop8 = AssistantSequenceGenerator.CreateDouble(position + 8);
            value.Prop9 = AssistantSequenceGenerator.CreateBool(position + 9);
        }

        static internal Builtins Create(uint position)
        {
            var result = new Builtins();
            Populate(result, position);
            return result;
        }

        #region Enumerator
        private class BuiltinsEnumerator : IEnumerator, IEnumerator<Builtins>, IDisposable
        {
            #region Properties
            private uint _position;
            private Builtins _current;
            #endregion

            private void PopulateCurrent()
            {
                _current = BuiltinsSequenceGenerator.Create(_position);
            }

            #region IDisposable
            public void Dispose()
            {
            }
            #endregion

            #region IEnumerator implementation
            public bool MoveNext()
            {
                ++_position;
                PopulateCurrent();
                return true;
            }

            public void Reset()
            {
                _position = 0;
                PopulateCurrent();
            }

            public object Current {
                get
                {
                    return _current;
                }
            }

            Builtins IEnumerator<Builtins>.Current
            {
                get
                {
                    return _current;
                }
            }
            #endregion

            public BuiltinsEnumerator()
            {
                PopulateCurrent();
            }
        }
        #endregion

        #region Enumerable
        private class BuiltinsEnumerable : IEnumerable, IEnumerable<Builtins>
        {
            #region IEnumerable implementation
            public IEnumerator GetEnumerator()
            {
                return new BuiltinsEnumerator();
            }

            IEnumerator<Builtins> IEnumerable<Builtins>.GetEnumerator()
            {
                return new BuiltinsEnumerator();
            }
            #endregion
        }
        #endregion

        static public IEnumerable<Builtins> Sequence()
        {
            return new BuiltinsEnumerable();
        }
    }
}
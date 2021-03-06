﻿//  ----------------------------------------------------------------------------------
//  Copyright Microsoft Corporation
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  http://www.apache.org/licenses/LICENSE-2.0
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  ----------------------------------------------------------------------------------

namespace DurableTask
{
    using System;

    public class DefaultObjectCreator<T> : ObjectCreator<T>
    {
        readonly T instance;
        readonly Type prototype;

        public DefaultObjectCreator(Type type)
        {
            prototype = type;
            Initialize(type);
        }

        public DefaultObjectCreator(T instance)
        {
            this.instance = instance;
            Initialize(instance);
        }

        public override T Create()
        {
            if (prototype != null)
            {
                return (T) Activator.CreateInstance(prototype);
            }

            return instance;
        }

        void Initialize(object obj)
        {
            Name = NameVersionHelper.GetDefaultName(obj);
            Version = NameVersionHelper.GetDefaultVersion(obj);
        }
    }
}
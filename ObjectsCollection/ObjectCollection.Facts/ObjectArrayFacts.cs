using System;
using Xunit;
using ObjectsCollection;

namespace ObjectsCollection.Facts
{
    public class ObjectArrayFacts
    {
        [Fact]
        public void ObjectArrayFact()
        {
            var obj = new ObjectArray();

            object obj1 = 5;

            Assert.True(obj.Count == 0);

            obj.Add(obj1);
            Assert.True(obj.IndexOf(obj1) == 0);
            Assert.True(obj.Count == 1);

            Assert.Equal(obj1, obj[0]);

            object obj2 = 3;
            obj.Add(obj2);
            Assert.True(obj.Count == 2);
            Assert.True(obj.IndexOf(obj2) == 1);
            Assert.Equal(obj2, obj[1]);

            object obj3 = 2;
            obj[0] = obj3;
            Assert.True(obj.IndexOf(obj3) == 0);

            
            obj.Remove(obj3);
            Assert.True(obj.Count == 1);
            Assert.True(obj.IndexOf(obj2) == 0);
            Assert.True(obj.Contains(obj2));

            obj3 = 1;
            obj.Insert(0, obj3);
            Assert.True(obj.IndexOf(obj3) == 0);
            Assert.True(obj.IndexOf(obj2) == 1);

            obj.Remove(obj3);
            Assert.True(obj.IndexOf(obj2) == 0);
            Assert.True(obj.Count == 1);


            obj1 = "string";
            obj.Add(obj1);
            Assert.True(obj.IndexOf(obj1) == 1);

            obj1 = String.Empty;
            obj.Add(obj1);
            Assert.True(obj[2] == String.Empty);
            obj.Remove(String.Empty);
            Assert.True(obj.Count == 2);

            obj1 = false;
            obj.Add(obj1);
            Assert.True((bool)obj[2] == false);

            obj1 = 3.1;
            obj.Add(obj1);
            Assert.True((double)obj[3] == 3.1);

            obj1 = "string1";
            obj2 = "string1";
            obj.Add(obj1);
            Assert.True(obj.IndexOf(obj2) == 4);
        }
    }
}

using FluentAssertions;
using System.Text;

namespace ReverseNumberTesting
{


    public class UnitTest1
    {
        [Theory]
        [InlineData(123, 321)]
        [InlineData(-123, -321)]
        [InlineData(120, 21)]
        [InlineData(1534236469, 0)]
        public void Test1(int x, int expectedOutput)
        {
            Reverse(x).Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData(true, 1, 1, 0, 0, 0, 1)]
        [InlineData(false, 2, 1,0,0,0,1)]
        [InlineData(false, 2, 1, 0, 0, 0, 0, 1)]
        [InlineData(true, 2, 1, 0, 0, 0, 1, 0, 0)]

        public void TestFlowers(bool expected, int n, params int[] flowerbed)
        {
            CanPlaceFlowers(flowerbed, n).Should().Be(expected);
        }


        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            if (flowerbed == null) return false;
            var maxIndex = flowerbed.Length - 1; ;

            if (maxIndex <0) return false;
           
            
           
            for (int i = 0; i <= maxIndex; i++)
            {
                var currentBed = flowerbed?[i];
                var NextBed = i== maxIndex?0:flowerbed?[i+1]??0;
                var PreviousBed = i==0?0:flowerbed?[i-1]??0;
                if (currentBed is null) break ;
                var currentBedValue = currentBed.Value;
                if (currentBedValue == 0 && PreviousBed ==0 && NextBed==0)
                {

                        n--;
                        i++;
                    
                }
               
            }
            return n <= 0;
        }
           
           
          

            
        





        [Theory]
        [InlineData(123, 2, 1, 2, 3, 4, 5)]
        public void Test32(int expected, int x, params int[] inputs)
        {
            ListNode nodeToParse = new ListNode(inputs[0]);
            ListNode iterator = nodeToParse;
            for (int i = 1; i < inputs.Count(); i++)
            {
                iterator = new ListNode(i);
                iterator = iterator.next;
            }
            RemoveNthFromEnd(nodeToParse, x).Should().Be(expected);
        }

        [Theory]
        [InlineData("123", 123)]
        [InlineData("4193 with words", 4193)]
        [InlineData("   -42", -42)]
        [InlineData("-91283472332", -2147483648)]
        [InlineData("00000-42a1234", 0)]
        public void Test2(string s, int expectedOutput)
        {


            MyAtoi(s).Should().Be(expectedOutput);
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head.next == null && n == 1) return null;
            var firsItemRef = head;
            Dictionary<int, ListNode> listNodesReferences = new Dictionary<int, ListNode>();
            int counter = 0;
            while (head != null)
            {
                listNodesReferences[counter++] = head;
                head = head.next;
            }
            int previousItemIndex = listNodesReferences.Count - n - 1;
            int nextItemIndex = listNodesReferences.Count - n + 1;
            ListNode nextNode;

            ListNode node;
            if (listNodesReferences.TryGetValue(nextItemIndex, out nextNode))
            {

            }

            if (listNodesReferences.TryGetValue(previousItemIndex, out node))
            {

            }

            if (nextNode != null && node != null) node.next = nextNode;
            if (nextNode == null && node != null) node.next = null;
            if (nextNode != null && node == null) return nextNode;
            return firsItemRef;
        }
        public int MyAtoi(string s)
        {
            int result = 0;
            if (s is null || s.Count() == 0) return result;
            string trimmedString = s.Trim();
            bool negativeResult = false;
            bool signSpotted = false;
            for (int i = 0; i < trimmedString.Length; i++)
            {
                char c = trimmedString[i];
                if (!signSpotted && c == '-' && i == 0)
                {
                    negativeResult = true;
                    signSpotted = true;
                }
                else if (!signSpotted && c == '+' && i == 0)
                {
                    signSpotted = true;
                    negativeResult = false;
                }
                else
                {
                    int res;
                    if (int.TryParse(trimmedString[i].ToString(), out res))
                    {
                        if (!negativeResult && (result > int.MaxValue / 10 || result == int.MaxValue / 10 && res > 7))
                        {
                            return int.MaxValue;
                        }
                        if (negativeResult && (-result < int.MinValue / 10 || -result == int.MinValue / 10 && res > 8))
                        {
                            return int.MinValue;
                        }


                        result = result * 10 + (negativeResult ? -res : res);
                    }
                    else
                    {
                        break;
                    }

                }

            }
            return negativeResult ? (-1 * result) : result;
        }

        [Theory]
        [InlineData("abc", "pqr", "apbqcr")]
        public void TestMerge(string word1, string word2, string expectedResult)
        {
            MergeAlternately(word1, word2).Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("  hello world  ", "world hello")]
        [InlineData("a good   example", "example good a")]
        public void TestReverse(string word1, string expectedResult)
        {
            ReverseWords(word1).Should().Be(expectedResult);
        }

        public string ReverseWords(string s)
        {
            var resultingString = s.Trim();

            var everyWord = resultingString.Split(' ');

            int size = everyWord.Length - 1;
            StringBuilder sb = new StringBuilder();
            //find words
            for (int i = size; i >= 0; i--)
            {
                string? appendThis = everyWord?[i];
                if (string.IsNullOrEmpty(appendThis)) continue;
                if (i < size) sb.Append(" ");
                sb.Append(appendThis);
            }

            return sb.ToString();
        }


        [Theory]
        [InlineData(49, 1, 8, 6, 2, 5, 4, 8, 3, 7)]
        [InlineData(2, 1, 2, 1)]
        public void TestMaxArea(int expectedResult, params int[] word1)
        {
            MaxArea(word1).Should().Be(expectedResult);
        }

        public int MaxArea(int[] height)
        {
            int totalMax = 0;
            int maxIndex = height.Length - 1;
            if (height == null || height.Length == 0 || height.Length == 1) return totalMax;

            for (int BaseElementIndex = 0, checkerElementIndex = maxIndex; BaseElementIndex <= maxIndex;)
            {

                if (BaseElementIndex == checkerElementIndex)
                {
                    var nextElement = checkerElementIndex - 1 ;
                    if (nextElement<0)
                    {
                        BaseElementIndex++;
                        checkerElementIndex = maxIndex;
                    }
                    else
                    {
                        checkerElementIndex = nextElement;
                    }
                    continue;
                }

                    var BaseCurrentItemValue = height[BaseElementIndex];
                var checkerItemValue = height[checkerElementIndex];
                
                if (checkerItemValue < BaseCurrentItemValue)
                {
                    var nextElement = checkerElementIndex - 1;
                    if (nextElement < 0)
                    {
                        BaseElementIndex++;
                        checkerElementIndex = maxIndex;
                       
                    }
                    else
                    {
                        checkerElementIndex = nextElement;
                    }
                }
                else
                {
                    var area = Math.Abs(checkerElementIndex - BaseElementIndex) * BaseCurrentItemValue;
                    totalMax = totalMax > area ? totalMax : area;
                    BaseElementIndex++;
                    checkerElementIndex = maxIndex;
                }
            }

            return totalMax;
        }

        public string MergeAlternately(string word1, string word2)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var stringSize1 = word1.Count();
            var stringSize2 = word2.Count();
            int length = stringSize1 > stringSize2 ? stringSize1 : stringSize2;

            for (int i = 0; i < length; i++)
            {
                if (i < stringSize1) stringBuilder.Append(word1[i]);
                if (i < stringSize2) stringBuilder.Append(word2[i]);
            }

            return stringBuilder.ToString();
        }

        public int Reverse(int x)
        {
            int reversedNumber = 0;
            if (x == 0) return reversedNumber;
            do
            {
                int pop = x % 10;
                int result;
                if (reversedNumber > int.MaxValue / 10 || reversedNumber == int.MaxValue / 10 && pop > 7)
                {
                    return 0;
                }
                if (reversedNumber < int.MinValue / 10 || reversedNumber == int.MinValue && pop < -8)
                {
                    return 0;
                }
                else reversedNumber = reversedNumber * 10 + pop;
                //2147483648
                x /= 10;

            } while (x != 0);
            return reversedNumber;
        }
    }
}
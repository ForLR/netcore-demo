using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreModel
{
    public class Student:IPerson
    {
        public int id { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_time { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int age { get; set; }
        public Task<List<long>> GetIds()
        {
            return Task.FromResult(new List<long>() { 1000, 200, 300 });
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyDiary.Models;

namespace MyDiary.Models
{
    public class MyDiaryContext : DbContext
    {
        public MyDiaryContext (DbContextOptions<MyDiaryContext> options)
            : base(options)
        {
        }

        public DbSet<MyDiary.Models.Content> Content { get; set; }

        public DbSet<MyDiary.Models.Review> Review { get; set; }
    }
}

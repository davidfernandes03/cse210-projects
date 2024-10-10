using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating Videos
        Video video1 = new Video("Music for Chill and Relax", "Lofi Girl", 7400);
        Video video2 = new Video("C# Tutorial", "Dev Professor", 1200);
        Video video3 = new Video("MatPat's FINAL Theory!", "The Game Theorists", 1524);

        // Adding Comments
        video1.AddComment(new Comment("Lily", "I never was sad"));
        video1.AddComment(new Comment("Jane", "Try to leave this video challenge (impossible)"));
        video1.AddComment(new Comment("Sans", "Bro I'm chilling and relaxing"));
        video1.AddComment(new Comment("Lena", "My favorite companion for studying *heart emoji*"));

        video2.AddComment(new Comment("Enzo", "Nice video!"));
        video2.AddComment(new Comment("Leyley", "He's not a man, he's a dad!"));
        video2.AddComment(new Comment("Jess", "Very clean explanation, thanks a lot dude"));

        video3.AddComment(new Comment("Scott", "MatPat's never dies!"));
        video3.AddComment(new Comment("Toby", "The end of an era"));
        video3.AddComment(new Comment("Mabel", "Who's gonna make the craziest theories now??? *crying emoji*"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos) {
            video.DisplayVideoDetails();
            Console.WriteLine();
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 70)));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Lib.Days._2022
{

    public class _2022Day07 : BaseDay, IDay
    {
        public _2022Day07(bool useExampleInput = false) : base(2022, 07, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var terminalOutputs = _input.ToStrArrayBySplittingRowsAndRemovingEmptyEntries();

            var root = CreateTreeFromTerminalOutput(terminalOutputs);
            var totalSum = 0;

            var subFolders = root.GetSubFolders();

            foreach (var folder in subFolders)
            {
                var size = folder.GetFolderSize();
                if (size <= 100000)
                {
                    totalSum += size;
                }
            }

            return totalSum.ToString();
        }

        public string SecondPuzzle()
        {
            var terminalOutputs = _input.ToStrArrayBySplittingRowsAndRemovingEmptyEntries();

            var root = CreateTreeFromTerminalOutput(terminalOutputs);
            var systemSize = 70000000;
            var totalSpaceNeeded = 30000000;

            var rootSize = root.GetFolderSize();
            var unusedSpace = systemSize - rootSize;
            var spaceNeededToBeDeleted = totalSpaceNeeded - unusedSpace;

            var subFolders = root.GetSubFolders();

            var folderSizesThatCouldBeDeleted = new List<int>();

            foreach (var folder in subFolders)
            {
                var size = folder.GetFolderSize();
                if (size >= spaceNeededToBeDeleted)
                {
                    folderSizesThatCouldBeDeleted.Add(size);
                }
            }

            return folderSizesThatCouldBeDeleted.Min().ToString();
        }

        private Folder CreateTreeFromTerminalOutput(string[] terminalOutputs)
        {
            var root = new Folder(null);
            var currentTreeObject = root;

            foreach (var output in terminalOutputs)
            {
                var outputParts = output.Split(" ");

                if (outputParts[0] == "$") // new command
                {
                    if (outputParts[1] == "cd")
                    {
                        if (outputParts[2] == "/")  // move to root
                        {
                            currentTreeObject = root;
                        }
                        else if (outputParts[2] == "..") // move down
                        {
                            currentTreeObject = currentTreeObject.Parent;
                        }
                        else // move up
                        {
                            currentTreeObject = currentTreeObject.SubObjects[outputParts[2]] as Folder;
                        }
                    }
                    else if (outputParts[1] == "ls") // no action here
                    {
                    }
                }
                else // listing files and folders
                {
                    if (outputParts[0] == "dir") // add dir
                    {
                        currentTreeObject.SubObjects.Add(outputParts[1], new Folder(currentTreeObject));
                    }
                    else // add file
                    {
                        currentTreeObject.SubObjects.Add(outputParts[1], new File(int.Parse(outputParts[0])));
                    }
                }
            }

            return root;
        }
    }

    public class TreeObject
    {
    }

    public class Folder : TreeObject
    {
        public Dictionary<string, TreeObject> SubObjects { get; set; }
        public Folder? Parent { get; set; }

        public Folder(Folder parent)
        {
            SubObjects = new Dictionary<string, TreeObject>();
            Parent = parent;
        }

        public List<Folder> GetSubFolders()
        {
            List<Folder> subFolders = new List<Folder>();

            foreach (var subObject in SubObjects)
            {
                if (subObject.Value is Folder)
                {
                    var folder = (Folder)subObject.Value;
                    subFolders.Add(folder);
                    subFolders.AddRange(folder.GetSubFolders());
                }
            }

            return subFolders;
        }
                
        public int GetFolderSize()
        {
            var folderSize = 0;

            foreach (var subObject in SubObjects)
            {
                if (subObject.Value is Folder)
                {
                    folderSize += (subObject.Value as Folder).GetFolderSize();
                }
                else
                {
                    folderSize += (subObject.Value as File).Size;
                }
            }

            return folderSize;
        }
    }

    public class File : TreeObject
    {
        public int Size { get; set; }

        public File(int size)
        {
            Size = size;
        }
    }

}

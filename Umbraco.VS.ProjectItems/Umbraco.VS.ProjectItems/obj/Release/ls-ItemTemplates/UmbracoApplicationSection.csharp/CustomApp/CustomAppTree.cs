using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.businesslogic;
using umbraco.cms.presentation.Trees;

namespace $rootnamespace$
{
    /// <summary>
    /// Registers our custom Tree in our new Application Section in Umbraco.
    /// 
    /// Documentation
    /// http://www.theoutfield.net/blog/2012/07/creating-custom-applications-and-trees-in-umbraco-48plus
    /// http://this.isfluent.com/2013/3/how-to-add-a-custom-application-to-umbraco-48/
    /// http://www.robertgray.net.au/posts/2011/5/creating-a-custom-content-tree-in-umbraco.aspx#.UllH9lC9KnQ
    /// </summary>
    [Tree("myCustomAppAlias", "myCustomAppTree", "Custom Tree")]
    public class $safeitemrootname$ : BaseTree
    {
        public $safeitemrootname$(string application) : base(application)
        {
        }

        /// <summary>
        /// Creates the Root Node for the custom tree
        /// </summary>
        /// <param name="rootNode"></param>
        protected override void CreateRootNode(ref XmlTreeNode rootNode)
        {
            rootNode.Icon       = FolderIcon;
            rootNode.OpenIcon   = FolderIconOpen;
            rootNode.NodeType   = TreeAlias;
            rootNode.NodeID     = "init";
        }

        /// <summary>
        /// For each node in the tree render the node
        /// </summary>
        /// <param name="tree"></param>
        public override void Render(ref XmlTree tree)
        {           
            //Create a list of Team Members
            //Obviously you would get it from a DB table, XML or 3rd party API
            var umbracoTeam = new List<TeamMember>();
            umbracoTeam.Add(new TeamMember({ Id = 1, Name = "Niels Hartvig", Location = "Denmark" });
            umbracoTeam.Add(new TeamMember({ Id = 2, Name = "Per Ploug", Location = "Denmark" });
            umbracoTeam.Add(new TeamMember({ Id = 3, Name = "Tim Geyssens", Location = "Belgium" });
            umbracoTeam.Add(new TeamMember({ Id = 4, Name = "Paul Sterling", Location = "USA" });
            umbracoTeam.Add(new TeamMember({ Id = 5, Name = "Shannon Demminick", Location = "Australia" });
            umbracoTeam.Add(new TeamMember({ Id = 6, Name = "Morten Christensen", Location = "Denmark" });
            umbracoTeam.Add(new TeamMember({ Id = 7, Name = "Sebastiaan Janssen", Location = "Denmark" });
            umbracoTeam.Add(new TeamMember({ Id = 8, Name = "Anders Stentebjerg", Location = "Denmark" });
    

            //For each Umbraco Team Member
            foreach(var teamMember in umbracoTeam) {
                //Create a node
                var dNode = XmlTreeNode.Create(this);

                //Set the node values
                dNode.NodeID        = teamMember.Id.ToString();
                dNode.Text          = teamMember.Name;
                dNode.Icon          = "user.png";
                dNode.Action        = "javascript:openTeamMember(" + teamMember.Id + ","  + teamMember.Name + ")";
                dNode.HasChildren   = false;
                dNode.NodeType      = "teamMember";

                //Add the node to the tree
                tree.Add(dNode);
            }            
        }

        /// <summary>
        /// For each node in the tree when the node is clicked run this JavaScript
        /// </summary>
        /// <param name="Javascript"></param>
        public override void RenderJS(ref System.Text.StringBuilder Javascript)
        {
            Javascript.Append(
                @"
                    function openTeamMember(id, name) 
                    {
                        //Simple test
                        alert('Hello ' + name);

                        //Obviously you would do something more useful like this and update the main view URL
                        //parent.right.document.location.href = 'plugins/CustomApp/editTeamMember.aspx?id=' + id;
                    }
                ");
        }
    }

    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
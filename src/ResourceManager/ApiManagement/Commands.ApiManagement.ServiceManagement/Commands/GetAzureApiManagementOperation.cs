﻿//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;

    [Cmdlet(VerbsCommon.Get, "AzureApiManagementOperation", DefaultParameterSetName = AllApiOperations)]
    [OutputType(typeof(IList<PsApiManagementOperation>))]
    public class GetAzureApiManagementOperation : AzureApiManagementCmdletBase
    {
        private const string FindById = "Find by ID";
        private const string AllApiOperations = "All API Operations";

        [Parameter(
            ValueFromPipelineByPropertyName = true, 
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = AllApiOperations,
            ValueFromPipelineByPropertyName = true, 
            Mandatory = true, 
            HelpMessage = "Identifier of API Operation belongs to. This parameter is required.")]
        [Parameter(
            ParameterSetName = FindById,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of API Operation belongs to. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ApiId { get; set; }

        [Parameter(
            ParameterSetName = FindById,
            ValueFromPipelineByPropertyName = true, 
            Mandatory = true, 
            HelpMessage = "Identifier operation to look for. This parameter is optional.")]
        public String OperationId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            if (ParameterSetName.Equals(AllApiOperations))
            {
                WriteObject(Client.OperationList(Context, ApiId), true);
            }
            else if (ParameterSetName.Equals(FindById))
            {
                WriteObject(Client.OperationById(Context, ApiId, OperationId));
            }
            else 
            {
                throw new InvalidOperationException(string.Format("Parameter set name '{0}' is not supported.", ParameterSetName));
            }
        }
    }
}P s A p i M a n a g e m e n t C o n t e x t   C o n t e x t   {   g e t ;   s e t ;   } 
 
                 [ P a r a m e t e r ( 
                         P a r a m e t e r S e t N a m e   =   A l l A p i O p e r a t i o n s , 
                         V a l u e F r o m P i p e l i n e B y P r o p e r t y N a m e   =   t r u e ,   
                         M a n d a t o r y   =   t r u e ,   
                         H e l p M e s s a g e   =   " I d e n t i f i e r   o f   A P I   O p e r a t i o n   b e l o n g s   t o .   T h i s   p a r a m e t e r   i s   r e q u i r e d . " ) ] 
                 [ P a r a m e t e r ( 
                         P a r a m e t e r S e t N a m e   =   F i n d B y I d , 
                         V a l u e F r o m P i p e l i n e B y P r o p e r t y N a m e   =   t r u e , 
                         M a n d a t o r y   =   t r u e , 
                         H e l p M e s s a g e   =   " I d e n t i f i e r   o f   A P I   O p e r a t i o n   b e l o n g s   t o .   T h i s   p a r a m e t e r   i s   r e q u i r e d . " ) ] 
                 [ V a l i d a t e N o t N u l l O r E m p t y ] 
                 p u b l i c   S t r i n g   A p i I d   {   g e t ;   s e t ;   } 
 
                 [ P a r a m e t e r ( 
                         P a r a m e t e r S e t N a m e   =   F i n d B y I d , 
                         V a l u e F r o m P i p e l i n e B y P r o p e r t y N a m e   =   t r u e ,   
                         M a n d a t o r y   =   t r u e ,   
                         H e l p M e s s a g e   =   " I d e n t i f i e r   o p e r a t i o n   t o   l o o k   f o r .   T h i s   p a r a m e t e r   i s   o p t i o n a l . " ) ] 
                 p u b l i c   S t r i n g   O p e r a t i o n I d   {   g e t ;   s e t ;   } 
 
                 p u b l i c   o v e r r i d e   v o i d   E x e c u t e A p i M a n a g e m e n t C m d l e t ( ) 
                 { 
                         i f   ( P a r a m e t e r S e t N a m e . E q u a l s ( A l l A p i O p e r a t i o n s ) ) 
                         { 
                                 W r i t e O b j e c t ( C l i e n t . O p e r a t i o n L i s t ( C o n t e x t ,   A p i I d ) ,   t r u e ) ; 
                         } 
                         e l s e   i f   ( P a r a m e t e r S e t N a m e . E q u a l s ( F i n d B y I d ) ) 
                         { 
                                 W r i t e O b j e c t ( C l i e n t . O p e r a t i o n B y I d ( C o n t e x t ,   A p i I d ,   O p e r a t i o n I d ) ) ; 
                         } 
                         e l s e   
                         { 
                                 t h r o w   n e w   I n v a l i d O p e r a t i o n E x c e p t i o n ( s t r i n g . F o r m a t ( " P a r a m e t e r   s e t   n a m e   ' { 0 } '   i s   n o t   s u p p o r t e d . " ,   P a r a m e t e r S e t N a m e ) ) ; 
                         } 
                 } 
}

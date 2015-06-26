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

    [Cmdlet(VerbsCommon.Get, "AzureApiManagementProduct", DefaultParameterSetName = GetAllProducts)]
    [OutputType(typeof(IList<PsApiManagementProduct>))]
    public class GetAzureApiManagementProduct : AzureApiManagementCmdletBase
    {
        private const string GetAllProducts = "Get all producst";
        private const string GetById = "Get by Id";
        private const string GetByTitle = "Get by Title";

        [Parameter(            
            ValueFromPipelineByPropertyName = true, 
            Mandatory = true, 
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = GetById,
            ValueFromPipelineByPropertyName = true, 
            Mandatory = true,
            HelpMessage = "Identifier of Product to search for. This parameter is optional.")]
        [ValidateNotNullOrEmpty]
        public String ProductId { get; set; }

        [Parameter(
            ParameterSetName = GetByTitle,
            ValueFromPipelineByPropertyName = true, 
            Mandatory = false,
            HelpMessage = "Title of the Product to look for. If specified will try to get the Product by title. This parameter is optional.")]
        public String Title { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            if (ParameterSetName.Equals(GetAllProducts))
            {
                var products = Client.ProductList(Context, null);
                WriteObject(products, true);
            }
            else if (ParameterSetName.Equals(GetById))
            {
                var product = Client.ProductById(Context, ProductId);
                WriteObject(product);
            }
            else if (ParameterSetName.Equals(GetByTitle))
            {
                var products = Client.ProductList(Context, Title);
                WriteObject(products, true);
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
                         P a r a m e t e r S e t N a m e   =   G e t B y I d , 
                         V a l u e F r o m P i p e l i n e B y P r o p e r t y N a m e   =   t r u e ,   
                         M a n d a t o r y   =   t r u e , 
                         H e l p M e s s a g e   =   " I d e n t i f i e r   o f   P r o d u c t   t o   s e a r c h   f o r .   T h i s   p a r a m e t e r   i s   o p t i o n a l . " ) ] 
                 [ V a l i d a t e N o t N u l l O r E m p t y ] 
                 p u b l i c   S t r i n g   P r o d u c t I d   {   g e t ;   s e t ;   } 
 
                 [ P a r a m e t e r ( 
                         P a r a m e t e r S e t N a m e   =   G e t B y T i t l e , 
                         V a l u e F r o m P i p e l i n e B y P r o p e r t y N a m e   =   t r u e ,   
                         M a n d a t o r y   =   f a l s e , 
                         H e l p M e s s a g e   =   " T i t l e   o f   t h e   P r o d u c t   t o   l o o k   f o r .   I f   s p e c i f i e d   w i l l   t r y   t o   g e t   t h e   P r o d u c t   b y   t i t l e .   T h i s   p a r a m e t e r   i s   o p t i o n a l . " ) ] 
                 p u b l i c   S t r i n g   T i t l e   {   g e t ;   s e t ;   } 
 
                 p u b l i c   o v e r r i d e   v o i d   E x e c u t e A p i M a n a g e m e n t C m d l e t ( ) 
                 { 
                         i f   ( P a r a m e t e r S e t N a m e . E q u a l s ( G e t A l l P r o d u c t s ) ) 
                         { 
                                 v a r   p r o d u c t s   =   C l i e n t . P r o d u c t L i s t ( C o n t e x t ,   n u l l ) ; 
                                 W r i t e O b j e c t ( p r o d u c t s ,   t r u e ) ; 
                         } 
                         e l s e   i f   ( P a r a m e t e r S e t N a m e . E q u a l s ( G e t B y I d ) ) 
                         { 
                                 v a r   p r o d u c t   =   C l i e n t . P r o d u c t B y I d ( C o n t e x t ,   P r o d u c t I d ) ; 
                                 W r i t e O b j e c t ( p r o d u c t ) ; 
                         } 
                         e l s e   i f   ( P a r a m e t e r S e t N a m e . E q u a l s ( G e t B y T i t l e ) ) 
                         { 
                                 v a r   p r o d u c t s   =   C l i e n t . P r o d u c t L i s t ( C o n t e x t ,   T i t l e ) ; 
                                 W r i t e O b j e c t ( p r o d u c t s ,   t r u e ) ; 
                         } 
                         e l s e 
                         { 
                                 t h r o w   n e w   I n v a l i d O p e r a t i o n E x c e p t i o n ( s t r i n g . F o r m a t ( " P a r a m e t e r   s e t   n a m e   ' { 0 } '   i s   n o t   s u p p o r t e d . " ,   P a r a m e t e r S e t N a m e ) ) ; 
                         } 
                 } 
}

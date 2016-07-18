/*------------------------------------------------------------------------------
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
------------------------------------------------------------------------------*/

namespace Amazon.AWS
{

    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01", IsNullable = false)]
    public partial class ItemSearchResponse
    {
        private ItemSearchResponseOperationRequest operationRequestField;
        private ItemSearchResponseItems itemsField;
        /// 
        public ItemSearchResponseOperationRequest OperationRequest
        {
            get
            {
                return this.operationRequestField;
            }
            set
            {
                this.operationRequestField = value;
            }
        }
        /// 
        public ItemSearchResponseItems Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseOperationRequest
    {
        private ItemSearchResponseOperationRequestHTTPHeaders hTTPHeadersField;
        private string requestIdField;
        private ItemSearchResponseOperationRequestArgument[] argumentsField;
        private decimal requestProcessingTimeField;
        /// 
        public ItemSearchResponseOperationRequestHTTPHeaders HTTPHeaders
        {
            get
            {
                return this.hTTPHeadersField;
            }
            set
            {
                this.hTTPHeadersField = value;
            }
        }
        /// 
        public string RequestId
        {
            get
            {
                return this.requestIdField;
            }
            set
            {
                this.requestIdField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlArrayItemAttribute("Argument", IsNullable = false)]
        public ItemSearchResponseOperationRequestArgument[] Arguments
        {
            get
            {
                return this.argumentsField;
            }
            set
            {
                this.argumentsField = value;
            }
        }
        /// 
        public decimal RequestProcessingTime
        {
            get
            {
                return this.requestProcessingTimeField;
            }
            set
            {
                this.requestProcessingTimeField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseOperationRequestHTTPHeaders
    {
        private ItemSearchResponseOperationRequestHTTPHeadersHeader headerField;
        /// 
        public ItemSearchResponseOperationRequestHTTPHeadersHeader Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseOperationRequestHTTPHeadersHeader
    {
        private string nameField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseOperationRequestArgument
    {
        private string nameField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItems
    {
        private ItemSearchResponseItemsRequest requestField;
        private uint totalResultsField;
        private uint totalPagesField;
        private string moreSearchResultsUrlField;
        private ItemSearchResponseItemsItem[] itemField;
        /// 
        public ItemSearchResponseItemsRequest Request
        {
            get
            {
                return this.requestField;
            }
            set
            {
                this.requestField = value;
            }
        }
        /// 
        public uint TotalResults
        {
            get
            {
                return this.totalResultsField;
            }
            set
            {
                this.totalResultsField = value;
            }
        }
        /// 
        public uint TotalPages
        {
            get
            {
                return this.totalPagesField;
            }
            set
            {
                this.totalPagesField = value;
            }
        }
        /// 
        public string MoreSearchResultsUrl
        {
            get
            {
                return this.moreSearchResultsUrlField;
            }
            set
            {
                this.moreSearchResultsUrlField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlElementAttribute("Item")]
        public ItemSearchResponseItemsItem[] Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsRequest
    {
        private string isValidField;
        private ItemSearchResponseItemsRequestItemSearchRequest itemSearchRequestField;
        /// 
        public string IsValid
        {
            get
            {
                return this.isValidField;
            }
            set
            {
                this.isValidField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsRequestItemSearchRequest ItemSearchRequest
        {
            get
            {
                return this.itemSearchRequestField;
            }
            set
            {
                this.itemSearchRequestField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsRequestItemSearchRequest
    {
        private string keywordsField;
        private string[] responseGroupField;
        private string searchIndexField;
        /// 
        public string Keywords
        {
            get
            {
                return this.keywordsField;
            }
            set
            {
                this.keywordsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlElementAttribute("ResponseGroup")]
        public string[] ResponseGroup
        {
            get
            {
                return this.responseGroupField;
            }
            set
            {
                this.responseGroupField = value;
            }
        }
        /// 
        public string SearchIndex
        {
            get
            {
                return this.searchIndexField;
            }
            set
            {
                this.searchIndexField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItem
    {
        private string aSINField;
        private string parentASINField;
        private string detailPageURLField;
        private ItemSearchResponseItemsItemItemLink[] itemLinksField;
        private string salesRankField;
        private ItemSearchResponseItemsItemSmallImage smallImageField;
        private ItemSearchResponseItemsItemMediumImage mediumImageField;
        private ItemSearchResponseItemsItemLargeImage largeImageField;
        private ItemSearchResponseItemsItemImageSet[] imageSetsField;
        private ItemSearchResponseItemsItemItemAttributes itemAttributesField;
        private ItemSearchResponseItemsItemOfferSummary offerSummaryField;
        private ItemSearchResponseItemsItemOffers offersField;
        private ItemSearchResponseItemsItemEditorialReviews editorialReviewsField;
        /// 
        public string ASIN
        {
            get
            {
                return this.aSINField;
            }
            set
            {
                this.aSINField = value;
            }
        }
        /// 
        public string ParentASIN
        {
            get
            {
                return this.parentASINField;
            }
            set
            {
                this.parentASINField = value;
            }
        }
        /// 
        public string DetailPageURL
        {
            get
            {
                return this.detailPageURLField;
            }
            set
            {
                this.detailPageURLField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlArrayItemAttribute("ItemLink", IsNullable = false)]
        public ItemSearchResponseItemsItemItemLink[] ItemLinks
        {
            get
            {
                return this.itemLinksField;
            }
            set
            {
                this.itemLinksField = value;
            }
        }
        /// 
        public string SalesRank
        {
            get
            {
                return this.salesRankField;
            }
            set
            {
                this.salesRankField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemSmallImage SmallImage
        {
            get
            {
                return this.smallImageField;
            }
            set
            {
                this.smallImageField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemMediumImage MediumImage
        {
            get
            {
                return this.mediumImageField;
            }
            set
            {
                this.mediumImageField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemLargeImage LargeImage
        {
            get
            {
                return this.largeImageField;
            }
            set
            {
                this.largeImageField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlArrayItemAttribute("ImageSet", IsNullable = false)]
        public ItemSearchResponseItemsItemImageSet[] ImageSets
        {
            get
            {
                return this.imageSetsField;
            }
            set
            {
                this.imageSetsField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemItemAttributes ItemAttributes
        {
            get
            {
                return this.itemAttributesField;
            }
            set
            {
                this.itemAttributesField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemOfferSummary OfferSummary
        {
            get
            {
                return this.offerSummaryField;
            }
            set
            {
                this.offerSummaryField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemOffers Offers
        {
            get
            {
                return this.offersField;
            }
            set
            {
                this.offersField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemEditorialReviews EditorialReviews
        {
            get
            {
                return this.editorialReviewsField;
            }
            set
            {
                this.editorialReviewsField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemLink
    {
        private string descriptionField;
        private string uRLField;
        /// 
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
        /// 
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemSmallImage
    {
        private string uRLField;
        private ItemSearchResponseItemsItemSmallImageHeight heightField;
        private ItemSearchResponseItemsItemSmallImageWidth widthField;
        /// 
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemSmallImageHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemSmallImageWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemSmallImageHeight
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemSmallImageWidth
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemMediumImage
    {
        private string uRLField;
        private ItemSearchResponseItemsItemMediumImageHeight heightField;
        private ItemSearchResponseItemsItemMediumImageWidth widthField;
        /// 
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemMediumImageHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemMediumImageWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemMediumImageHeight
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemMediumImageWidth
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemLargeImage
    {
        private string uRLField;
        private ItemSearchResponseItemsItemLargeImageHeight heightField;
        private ItemSearchResponseItemsItemLargeImageWidth widthField;
        /// 
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemLargeImageHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemLargeImageWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemLargeImageHeight
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemLargeImageWidth
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSet
    {
        private ItemSearchResponseItemsItemImageSetSwatchImage swatchImageField;
        private ItemSearchResponseItemsItemImageSetSmallImage smallImageField;
        private ItemSearchResponseItemsItemImageSetThumbnailImage thumbnailImageField;
        private ItemSearchResponseItemsItemImageSetTinyImage tinyImageField;
        private ItemSearchResponseItemsItemImageSetMediumImage mediumImageField;
        private ItemSearchResponseItemsItemImageSetLargeImage largeImageField;
        private string categoryField;
        /// 
        public ItemSearchResponseItemsItemImageSetSwatchImage SwatchImage
        {
            get
            {
                return this.swatchImageField;
            }
            set
            {
                this.swatchImageField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemImageSetSmallImage SmallImage
        {
            get
            {
                return this.smallImageField;
            }
            set
            {
                this.smallImageField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemImageSetThumbnailImage ThumbnailImage
        {
            get
            {
                return this.thumbnailImageField;
            }
            set
            {
                this.thumbnailImageField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemImageSetTinyImage TinyImage
        {
            get
            {
                return this.tinyImageField;
            }
            set
            {
                this.tinyImageField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemImageSetMediumImage MediumImage
        {
            get
            {
                return this.mediumImageField;
            }
            set
            {
                this.mediumImageField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemImageSetLargeImage LargeImage
        {
            get
            {
                return this.largeImageField;
            }
            set
            {
                this.largeImageField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSetSwatchImage
    {
        private string uRLField;
        private ItemSearchResponseItemsItemImageSetSwatchImageHeight heightField;
        private ItemSearchResponseItemsItemImageSetSwatchImageWidth widthField;
        /// 
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemImageSetSwatchImageHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemImageSetSwatchImageWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSetSwatchImageHeight
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSetSwatchImageWidth
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSetSmallImage
    {
        private string uRLField;
        private ItemSearchResponseItemsItemImageSetSmallImageHeight heightField;
        private ItemSearchResponseItemsItemImageSetSmallImageWidth widthField;
        /// 
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemImageSetSmallImageHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemImageSetSmallImageWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSetSmallImageHeight
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSetSmallImageWidth
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSetThumbnailImage
    {
        private string uRLField;
        private ItemSearchResponseItemsItemImageSetThumbnailImageHeight heightField;
        private ItemSearchResponseItemsItemImageSetThumbnailImageWidth widthField;
        /// 
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemImageSetThumbnailImageHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemImageSetThumbnailImageWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSetThumbnailImageHeight
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSetThumbnailImageWidth
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSetTinyImage
    {
        private string uRLField;
        private ItemSearchResponseItemsItemImageSetTinyImageHeight heightField;
        private ItemSearchResponseItemsItemImageSetTinyImageWidth widthField;
        /// 
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemImageSetTinyImageHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemImageSetTinyImageWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSetTinyImageHeight
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSetTinyImageWidth
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSetMediumImage
    {
        private string uRLField;
        private ItemSearchResponseItemsItemImageSetMediumImageHeight heightField;
        private ItemSearchResponseItemsItemImageSetMediumImageWidth widthField;
        /// 
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemImageSetMediumImageHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemImageSetMediumImageWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSetMediumImageHeight
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSetMediumImageWidth
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSetLargeImage
    {
        private string uRLField;
        private ItemSearchResponseItemsItemImageSetLargeImageHeight heightField;
        private ItemSearchResponseItemsItemImageSetLargeImageWidth widthField;
        /// 
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemImageSetLargeImageHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemImageSetLargeImageWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSetLargeImageHeight
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemImageSetLargeImageWidth
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributes
    {
        private string bindingField;
        private string brandField;
        private ItemSearchResponseItemsItemItemAttributesCatalogNumberList catalogNumberListField;
        private string eANField;
        private ItemSearchResponseItemsItemItemAttributesEANList eANListField;
        private string editionField;
        private string eSRBAgeRatingField;
        private ItemSearchResponseItemsItemItemAttributesFeature[] featureField;
        private string genreField;
        private string formatField;
        private string hardwarePlatformField;
        private string isEligibleForTradeInField;
        private bool isEligibleForTradeInFieldSpecified;
        private ItemSearchResponseItemsItemItemAttributesItemDimensions itemDimensionsField;
        private string labelField;
        private ItemSearchResponseItemsItemItemAttributesLanguage[] languagesField;
        private ItemSearchResponseItemsItemItemAttributesListPrice listPriceField;
        private string manufacturerField;
        private string modelField;
        private string mPNField;
        private bool mPNFieldSpecified;
        private string numberOfDiscsField;
        private bool numberOfDiscsFieldSpecified;
        private string numberOfItemsField;
        private bool numberOfItemsFieldSpecified;
        private string operatingSystemField;
        private ItemSearchResponseItemsItemItemAttributesPackageDimensions packageDimensionsField;
        private string packageQuantityField;
        private string partNumberField;
        private bool partNumberFieldSpecified;
        private string platformField;
        private string productGroupField;
        private string productTypeNameField;
        private System.DateTime publicationDateField;
        private bool publicationDateFieldSpecified;
        private string publisherField;
        private System.DateTime releaseDateField;
        private string studioField;
        private string titleField;
        private ItemSearchResponseItemsItemItemAttributesTradeInValue tradeInValueField;
        private string uPCField;
        private ItemSearchResponseItemsItemItemAttributesUPCList uPCListField;
        /// 
        public string Binding
        {
            get
            {
                return this.bindingField;
            }
            set
            {
                this.bindingField = value;
            }
        }
        /// 
        public string Brand
        {
            get
            {
                return this.brandField;
            }
            set
            {
                this.brandField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemItemAttributesCatalogNumberList CatalogNumberList
        {
            get
            {
                return this.catalogNumberListField;
            }
            set
            {
                this.catalogNumberListField = value;
            }
        }
        /// 
        public string EAN
        {
            get
            {
                return this.eANField;
            }
            set
            {
                this.eANField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemItemAttributesEANList EANList
        {
            get
            {
                return this.eANListField;
            }
            set
            {
                this.eANListField = value;
            }
        }
        /// 
        public string Edition
        {
            get
            {
                return this.editionField;
            }
            set
            {
                this.editionField = value;
            }
        }
        /// 
        public string ESRBAgeRating
        {
            get
            {
                return this.eSRBAgeRatingField;
            }
            set
            {
                this.eSRBAgeRatingField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlElementAttribute("Feature")]
        public ItemSearchResponseItemsItemItemAttributesFeature[] Feature
        {
            get
            {
                return this.featureField;
            }
            set
            {
                this.featureField = value;
            }
        }
        /// 
        public string Genre
        {
            get
            {
                return this.genreField;
            }
            set
            {
                this.genreField = value;
            }
        }
        /// 
        public string Format
        {
            get
            {
                return this.formatField;
            }
            set
            {
                this.formatField = value;
            }
        }
        /// 
        public string HardwarePlatform
        {
            get
            {
                return this.hardwarePlatformField;
            }
            set
            {
                this.hardwarePlatformField = value;
            }
        }
        /// 
        public string IsEligibleForTradeIn
        {
            get
            {
                return this.isEligibleForTradeInField;
            }
            set
            {
                this.isEligibleForTradeInField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsEligibleForTradeInSpecified
        {
            get
            {
                return this.isEligibleForTradeInFieldSpecified;
            }
            set
            {
                this.isEligibleForTradeInFieldSpecified = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemItemAttributesItemDimensions ItemDimensions
        {
            get
            {
                return this.itemDimensionsField;
            }
            set
            {
                this.itemDimensionsField = value;
            }
        }
        /// 
        public string Label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlArrayItemAttribute("Language", IsNullable = false)]
        public ItemSearchResponseItemsItemItemAttributesLanguage[] Languages
        {
            get
            {
                return this.languagesField;
            }
            set
            {
                this.languagesField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemItemAttributesListPrice ListPrice
        {
            get
            {
                return this.listPriceField;
            }
            set
            {
                this.listPriceField = value;
            }
        }
        /// 
        public string Manufacturer
        {
            get
            {
                return this.manufacturerField;
            }
            set
            {
                this.manufacturerField = value;
            }
        }
        /// 
        public string Model
        {
            get
            {
                return this.modelField;
            }
            set
            {
                this.modelField = value;
            }
        }
        /// 
        public string MPN
        {
            get
            {
                return this.mPNField;
            }
            set
            {
                this.mPNField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MPNSpecified
        {
            get
            {
                return this.mPNFieldSpecified;
            }
            set
            {
                this.mPNFieldSpecified = value;
            }
        }
        /// 
        public string NumberOfDiscs
        {
            get
            {
                return this.numberOfDiscsField;
            }
            set
            {
                this.numberOfDiscsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfDiscsSpecified
        {
            get
            {
                return this.numberOfDiscsFieldSpecified;
            }
            set
            {
                this.numberOfDiscsFieldSpecified = value;
            }
        }
        /// 
        public string NumberOfItems
        {
            get
            {
                return this.numberOfItemsField;
            }
            set
            {
                this.numberOfItemsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfItemsSpecified
        {
            get
            {
                return this.numberOfItemsFieldSpecified;
            }
            set
            {
                this.numberOfItemsFieldSpecified = value;
            }
        }
        /// 
        public string OperatingSystem
        {
            get
            {
                return this.operatingSystemField;
            }
            set
            {
                this.operatingSystemField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemItemAttributesPackageDimensions PackageDimensions
        {
            get
            {
                return this.packageDimensionsField;
            }
            set
            {
                this.packageDimensionsField = value;
            }
        }
        /// 
        public string PackageQuantity
        {
            get
            {
                return this.packageQuantityField;
            }
            set
            {
                this.packageQuantityField = value;
            }
        }
        /// 
        public string PartNumber
        {
            get
            {
                return this.partNumberField;
            }
            set
            {
                this.partNumberField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PartNumberSpecified
        {
            get
            {
                return this.partNumberFieldSpecified;
            }
            set
            {
                this.partNumberFieldSpecified = value;
            }
        }
        /// 
        public string Platform
        {
            get
            {
                return this.platformField;
            }
            set
            {
                this.platformField = value;
            }
        }
        /// 
        public string ProductGroup
        {
            get
            {
                return this.productGroupField;
            }
            set
            {
                this.productGroupField = value;
            }
        }
        /// 
        public string ProductTypeName
        {
            get
            {
                return this.productTypeNameField;
            }
            set
            {
                this.productTypeNameField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime PublicationDate
        {
            get
            {
                return this.publicationDateField;
            }
            set
            {
                this.publicationDateField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PublicationDateSpecified
        {
            get
            {
                return this.publicationDateFieldSpecified;
            }
            set
            {
                this.publicationDateFieldSpecified = value;
            }
        }
        /// 
        public string Publisher
        {
            get
            {
                return this.publisherField;
            }
            set
            {
                this.publisherField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime ReleaseDate
        {
            get
            {
                return this.releaseDateField;
            }
            set
            {
                this.releaseDateField = value;
            }
        }
        /// 
        public string Studio
        {
            get
            {
                return this.studioField;
            }
            set
            {
                this.studioField = value;
            }
        }
        /// 
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemItemAttributesTradeInValue TradeInValue
        {
            get
            {
                return this.tradeInValueField;
            }
            set
            {
                this.tradeInValueField = value;
            }
        }
        /// 
        public string UPC
        {
            get
            {
                return this.uPCField;
            }
            set
            {
                this.uPCField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemItemAttributesUPCList UPCList
        {
            get
            {
                return this.uPCListField;
            }
            set
            {
                this.uPCListField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesCatalogNumberList
    {
        private string catalogNumberListElementField;
        /// 
        public string CatalogNumberListElement
        {
            get
            {
                return this.catalogNumberListElementField;
            }
            set
            {
                this.catalogNumberListElementField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesEANList
    {
        private string eANListElementField;
        /// 
        public string EANListElement
        {
            get
            {
                return this.eANListElementField;
            }
            set
            {
                this.eANListElementField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesFeature
    {
        private ItemSearchResponseItemsItemItemAttributesFeatureA[] aField;
        private string[] textField;
        /// 
        [System.Xml.Serialization.XmlElementAttribute("a")]
        public ItemSearchResponseItemsItemItemAttributesFeatureA[] a
        {
            get
            {
                return this.aField;
            }
            set
            {
                this.aField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesFeatureA
    {
        private string hrefField;
        private string targetField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string href
        {
            get
            {
                return this.hrefField;
            }
            set
            {
                this.hrefField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string target
        {
            get
            {
                return this.targetField;
            }
            set
            {
                this.targetField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesItemDimensions
    {
        private ItemSearchResponseItemsItemItemAttributesItemDimensionsHeight heightField;
        private ItemSearchResponseItemsItemItemAttributesItemDimensionsLength lengthField;
        private ItemSearchResponseItemsItemItemAttributesItemDimensionsWeight weightField;
        private ItemSearchResponseItemsItemItemAttributesItemDimensionsWidth widthField;
        /// 
        public ItemSearchResponseItemsItemItemAttributesItemDimensionsHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemItemAttributesItemDimensionsLength Length
        {
            get
            {
                return this.lengthField;
            }
            set
            {
                this.lengthField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemItemAttributesItemDimensionsWeight Weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemItemAttributesItemDimensionsWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesItemDimensionsHeight
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesItemDimensionsLength
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesItemDimensionsWeight
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesItemDimensionsWidth
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesLanguage
    {
        private string nameField;
        private string typeField;
        /// 
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        /// 
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesListPrice
    {
        private string amountField;
        private string currencyCodeField;
        private string formattedPriceField;
        /// 
        public string Amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }
        /// 
        public string CurrencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }
        /// 
        public string FormattedPrice
        {
            get
            {
                return this.formattedPriceField;
            }
            set
            {
                this.formattedPriceField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesPackageDimensions
    {
        private ItemSearchResponseItemsItemItemAttributesPackageDimensionsHeight heightField;
        private ItemSearchResponseItemsItemItemAttributesPackageDimensionsLength lengthField;
        private ItemSearchResponseItemsItemItemAttributesPackageDimensionsWeight weightField;
        private ItemSearchResponseItemsItemItemAttributesPackageDimensionsWidth widthField;
        /// 
        public ItemSearchResponseItemsItemItemAttributesPackageDimensionsHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemItemAttributesPackageDimensionsLength Length
        {
            get
            {
                return this.lengthField;
            }
            set
            {
                this.lengthField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemItemAttributesPackageDimensionsWeight Weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemItemAttributesPackageDimensionsWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesPackageDimensionsHeight
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesPackageDimensionsLength
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesPackageDimensionsWeight
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesPackageDimensionsWidth
    {
        private string unitsField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesTradeInValue
    {
        private string amountField;
        private string currencyCodeField;
        private string formattedPriceField;
        /// 
        public string Amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }
        /// 
        public string CurrencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }
        /// 
        public string FormattedPrice
        {
            get
            {
                return this.formattedPriceField;
            }
            set
            {
                this.formattedPriceField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesUPCList
    {
        private string uPCListElementField;
        /// 
        public string UPCListElement
        {
            get
            {
                return this.uPCListElementField;
            }
            set
            {
                this.uPCListElementField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemOfferSummary
    {
        private ItemSearchResponseItemsItemOfferSummaryLowestNewPrice lowestNewPriceField;
        private ItemSearchResponseItemsItemOfferSummaryLowestUsedPrice lowestUsedPriceField;
        private string totalNewField;
        private string totalUsedField;
        private string totalCollectibleField;
        private string totalRefurbishedField;
        /// 
        public ItemSearchResponseItemsItemOfferSummaryLowestNewPrice LowestNewPrice
        {
            get
            {
                return this.lowestNewPriceField;
            }
            set
            {
                this.lowestNewPriceField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemOfferSummaryLowestUsedPrice LowestUsedPrice
        {
            get
            {
                return this.lowestUsedPriceField;
            }
            set
            {
                this.lowestUsedPriceField = value;
            }
        }
        /// 
        public string TotalNew
        {
            get
            {
                return this.totalNewField;
            }
            set
            {
                this.totalNewField = value;
            }
        }
        /// 
        public string TotalUsed
        {
            get
            {
                return this.totalUsedField;
            }
            set
            {
                this.totalUsedField = value;
            }
        }
        /// 
        public string TotalCollectible
        {
            get
            {
                return this.totalCollectibleField;
            }
            set
            {
                this.totalCollectibleField = value;
            }
        }
        /// 
        public string TotalRefurbished
        {
            get
            {
                return this.totalRefurbishedField;
            }
            set
            {
                this.totalRefurbishedField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemOfferSummaryLowestNewPrice
    {
        private string amountField;
        private string currencyCodeField;
        private string formattedPriceField;
        /// 
        public string Amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }
        /// 
        public string CurrencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }
        /// 
        public string FormattedPrice
        {
            get
            {
                return this.formattedPriceField;
            }
            set
            {
                this.formattedPriceField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemOfferSummaryLowestUsedPrice
    {
        private string amountField;
        private string currencyCodeField;
        private string formattedPriceField;
        /// 
        public string Amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }
        /// 
        public string CurrencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }
        /// 
        public string FormattedPrice
        {
            get
            {
                return this.formattedPriceField;
            }
            set
            {
                this.formattedPriceField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemOffers
    {
        private string totalOffersField;
        private string totalOfferPagesField;
        private string moreOffersUrlField;
        private ItemSearchResponseItemsItemOffersOffer offerField;
        /// 
        public string TotalOffers
        {
            get
            {
                return this.totalOffersField;
            }
            set
            {
                this.totalOffersField = value;
            }
        }
        /// 
        public string TotalOfferPages
        {
            get
            {
                return this.totalOfferPagesField;
            }
            set
            {
                this.totalOfferPagesField = value;
            }
        }
        /// 
        public string MoreOffersUrl
        {
            get
            {
                return this.moreOffersUrlField;
            }
            set
            {
                this.moreOffersUrlField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemOffersOffer Offer
        {
            get
            {
                return this.offerField;
            }
            set
            {
                this.offerField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemOffersOffer
    {
        private ItemSearchResponseItemsItemOffersOfferOfferAttributes offerAttributesField;
        private ItemSearchResponseItemsItemOffersOfferOfferListing offerListingField;
        /// 
        public ItemSearchResponseItemsItemOffersOfferOfferAttributes OfferAttributes
        {
            get
            {
                return this.offerAttributesField;
            }
            set
            {
                this.offerAttributesField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemOffersOfferOfferListing OfferListing
        {
            get
            {
                return this.offerListingField;
            }
            set
            {
                this.offerListingField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemOffersOfferOfferAttributes
    {
        private string conditionField;
        /// 
        public string Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemOffersOfferOfferListing
    {
        private string offerListingIdField;
        private ItemSearchResponseItemsItemOffersOfferOfferListingPrice priceField;
        private ItemSearchResponseItemsItemOffersOfferOfferListingAmountSaved amountSavedField;
        private string percentageSavedField;
        private bool percentageSavedFieldSpecified;
        private string availabilityField;
        private ItemSearchResponseItemsItemOffersOfferOfferListingAvailabilityAttributes availabilityAttributesField;
        private string isEligibleForSuperSaverShippingField;
        private string isEligibleForPrimeField;
        /// 
        public string OfferListingId
        {
            get
            {
                return this.offerListingIdField;
            }
            set
            {
                this.offerListingIdField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemOffersOfferOfferListingPrice Price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemOffersOfferOfferListingAmountSaved AmountSaved
        {
            get
            {
                return this.amountSavedField;
            }
            set
            {
                this.amountSavedField = value;
            }
        }
        /// 
        public string PercentageSaved
        {
            get
            {
                return this.percentageSavedField;
            }
            set
            {
                this.percentageSavedField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentageSavedSpecified
        {
            get
            {
                return this.percentageSavedFieldSpecified;
            }
            set
            {
                this.percentageSavedFieldSpecified = value;
            }
        }
        /// 
        public string Availability
        {
            get
            {
                return this.availabilityField;
            }
            set
            {
                this.availabilityField = value;
            }
        }
        /// 
        public ItemSearchResponseItemsItemOffersOfferOfferListingAvailabilityAttributes AvailabilityAttributes
        {
            get
            {
                return this.availabilityAttributesField;
            }
            set
            {
                this.availabilityAttributesField = value;
            }
        }
        /// 
        public string IsEligibleForSuperSaverShipping
        {
            get
            {
                return this.isEligibleForSuperSaverShippingField;
            }
            set
            {
                this.isEligibleForSuperSaverShippingField = value;
            }
        }
        /// 
        public string IsEligibleForPrime
        {
            get
            {
                return this.isEligibleForPrimeField;
            }
            set
            {
                this.isEligibleForPrimeField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemOffersOfferOfferListingPrice
    {
        private string amountField;
        private string currencyCodeField;
        private string formattedPriceField;
        /// 
        public string Amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }
        /// 
        public string CurrencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }
        /// 
        public string FormattedPrice
        {
            get
            {
                return this.formattedPriceField;
            }
            set
            {
                this.formattedPriceField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemOffersOfferOfferListingAmountSaved
    {
        private string amountField;
        private string currencyCodeField;
        private string formattedPriceField;
        /// 
        public string Amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }
        /// 
        public string CurrencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }
        /// 
        public string FormattedPrice
        {
            get
            {
                return this.formattedPriceField;
            }
            set
            {
                this.formattedPriceField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemOffersOfferOfferListingAvailabilityAttributes
    {
        private string availabilityTypeField;
        private string isPreorderField;
        private bool isPreorderFieldSpecified;
        private string minimumHoursField;
        private string maximumHoursField;
        /// 
        public string AvailabilityType
        {
            get
            {
                return this.availabilityTypeField;
            }
            set
            {
                this.availabilityTypeField = value;
            }
        }
        /// 
        public string IsPreorder
        {
            get
            {
                return this.isPreorderField;
            }
            set
            {
                this.isPreorderField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsPreorderSpecified
        {
            get
            {
                return this.isPreorderFieldSpecified;
            }
            set
            {
                this.isPreorderFieldSpecified = value;
            }
        }
        /// 
        public string MinimumHours
        {
            get
            {
                return this.minimumHoursField;
            }
            set
            {
                this.minimumHoursField = value;
            }
        }
        /// 
        public string MaximumHours
        {
            get
            {
                return this.maximumHoursField;
            }
            set
            {
                this.maximumHoursField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemEditorialReviews
    {
        private ItemSearchResponseItemsItemEditorialReviewsEditorialReview editorialReviewField;
        /// 
        public ItemSearchResponseItemsItemEditorialReviewsEditorialReview EditorialReview
        {
            get
            {
                return this.editorialReviewField;
            }
            set
            {
                this.editorialReviewField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemEditorialReviewsEditorialReview
    {
        private string sourceField;
        private string contentField;
        private string isLinkSuppressedField;
        /// 
        public string Source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }
        /// 
        public string Content
        {
            get
            {
                return this.contentField;
            }
            set
            {
                this.contentField = value;
            }
        }
        /// 
        public string IsLinkSuppressed
        {
            get
            {
                return this.isLinkSuppressedField;
            }
            set
            {
                this.isLinkSuppressedField = value;
            }
        }
    }
}
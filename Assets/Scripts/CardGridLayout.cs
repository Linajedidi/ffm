using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGridLayout : LayoutGroup
{
    public int rows;// Number of cards 
    public int columns; 
    public Vector2 cardSize ;
    public Vector2 spacing;

    public int topPadding;
    public override void CalculateLayoutInputVertical()
    {
        if(rows == 0 || columns == 0)
        {
            rows = 4;
            columns = 5;
        }
        float ParentWidth = rectTransform.rect.width;
        float ParentHeight = rectTransform.rect.height;
        float cardHeight = (ParentHeight - 2 * topPadding - spacing.y * (rows - 1 ))/ rows;
        float cardWidth = cardHeight;
        if (cardWidth * columns + spacing.x * (columns -1 )  > ParentWidth)
        {
            cardWidth = (ParentWidth - 2 * topPadding - (columns - 1) * spacing.x) /columns ;
            cardHeight = cardWidth; 
        }
        cardSize= new Vector2 (cardWidth, cardHeight);
        padding.left = Mathf.FloorToInt((ParentWidth - columns * cardWidth - spacing.x * (columns - 1 )) / 2);
        padding.top = Mathf.FloorToInt((ParentHeight - rows * cardHeight - spacing.y * (rows -1 )) / 2);
        padding.bottom = padding.top;
       
        for (int i = 0; i < rectChildren.Count; i++)
        { 
            int rowCount = i / columns;
            int columnCount = i % columns;
            var item = rectChildren[i];
            var xPos = padding.left + cardSize.x * columnCount + spacing.x * (columnCount) ; 
            var yPos = padding.top + cardSize.y * rowCount + spacing.y * (rowCount) ;
            SetChildAlongAxis(item, 0, xPos, cardSize.x);
            SetChildAlongAxis(item, 1, yPos, cardSize.y);




        }
    }

    public override void SetLayoutHorizontal()
    {
        return;
    }

    public override void SetLayoutVertical()
    {
        return; 
    }
}

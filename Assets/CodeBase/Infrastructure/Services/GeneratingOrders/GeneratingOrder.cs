using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services.WishList;
using CodeBase.Logic.Actors.Actors;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.GeneratingOrders
{
    public class GeneratingOrder : MonoBehaviour, IGeneratingOrder
    {
        private IWishListService _wishListService;
        
        private List<ViewingData> _queueViewings = new List<ViewingData>();
       
        private Coroutine _updateTimesCoroutine;

        [Inject]
        private void Construct(IWishListService wishListService)
        {
            _wishListService = wishListService;
        }
        
        public void ViewingWishList(Visitor visitor, Action<WishListItem> viewed)
        {
            WishListItem wishItem = _wishListService.GetRandomWishItem();
            
            ViewingData viewingData = new ViewingData(viewed, visitor.TimeViewWishList, wishItem);

            _queueViewings.Add(viewingData);
            
            _updateTimesCoroutine ??= StartCoroutine(UpdateTimesViewing());
        }

        private IEnumerator UpdateTimesViewing()
        {
            while (_queueViewings.Count > 0)
            {
                for (int i = 0; i < _queueViewings.Count; i++)
                {
                    if (_queueViewings[i].CheckTimer())
                    {
                        _queueViewings[i].ExecuteCallBack();
                        _queueViewings.RemoveAt(i);
                    }
                    else
                    {
                        _queueViewings[i].UpdateTimer(Time.deltaTime);
                    }
                }
                yield return null;
            }

            _updateTimesCoroutine = null;
        }
    }
}
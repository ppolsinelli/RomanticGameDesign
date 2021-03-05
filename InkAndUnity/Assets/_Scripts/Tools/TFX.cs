using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DG.DeAudio;
using DG.Tweening;
using TMPro;
using UnityEngine;
using static UnityEngine.Mathf;

namespace OL
{
    public static class TFX
    {
        /*
                 

        //------------------------------------------------------------------------------------------------
        // Reveal

        /// <summary>
        ///     Assumes parent of textComponent to be disabled at text show end
        /// </summary>
        /// <param name="textComponent"></param>
        /// <param name="text"></param>
        public static void RevealCharacters(RevealCharactersConfig cf, int startFromChar = 0)
        {
            cf.TextComponent.maxVisibleCharacters = startFromChar;
            cf.TextComponent.text = cf.Text;
            cf.TextComponent.transform.parent.gameObject.SetActive(true);
            var totalVisibleCharacters = startFromChar + cf.Text.Length;
            DoReveal(totalVisibleCharacters, cf);
        }

        public class RevealCharactersConfig
        {
            public TMP_Text TextComponent;
            public string Text;
            public float DelayBetweenCharReveal;
            public float TimePerCharWaitWhenFinished;
            public float AdditionalDelayOnCompletionCallback;
            public bool DisableParentOnEnd;
            public Action CallbackOnCompletionAfterPause;
            public Action CallbackOnTypeEnded;
            public Func<bool> VerifyEndTypeNow;
            public AudioClip Feedback;
            public Ease TypeEase = Ease.OutQuad;

            public float FitMarginX;
            public float FitMarginY;
            public SpriteRenderer FitThisImage;


            public RevealCharactersConfig(
             TMP_Text textComponent,
             string text,
             float delayBetweenCharReveal,
             float timePerCharWaitWhenFinished)
            {
                TextComponent = textComponent;
                Text = text;
                DelayBetweenCharReveal = delayBetweenCharReveal;
                TimePerCharWaitWhenFinished = timePerCharWaitWhenFinished;
            }

            public int FromChar;
        }

        static void DoReveal(
             int totalVisibleCharacters,
             RevealCharactersConfig cf
            )
        {
            if (cf.Feedback != null)
                DeAudioManager.Play(cf.Feedback);

            var tween = cf.TextComponent
                .DOMaxVisibleCharacters(totalVisibleCharacters,
                    cf.DelayBetweenCharReveal * totalVisibleCharacters);

            if (cf.FromChar > 0)
            {
                tween.From(cf.FromChar);
            }

            tween.SetEase(cf.TypeEase).SetId("DoReveal")
                .OnComplete(() =>
                {
                    if (cf.Feedback != null)
                        DeAudioManager.Stop(cf.Feedback);

                    if (cf.CallbackOnTypeEnded != null)
                        cf.CallbackOnTypeEnded();

                    DOVirtual.DelayedCall(
                        cf.TimePerCharWaitWhenFinished * cf.TextComponent.text.Length +
                        cf.AdditionalDelayOnCompletionCallback, () =>
                        {
                            if (cf.DisableParentOnEnd)
                            {
                                cf.TextComponent.text = "";
                                cf.TextComponent.transform.parent.gameObject.SetActive(false);
                            }

                            if (cf.CallbackOnCompletionAfterPause != null)
                                cf.CallbackOnCompletionAfterPause();
                        });
                });
        }
        */
        public class RollToScoreConfig
        {
            public TMP_Text textComponent;
            public int start;
            public int end;
            public int step;
            public Action callback;
            public string numberpostfix;
            public AudioClip feedback;
        }

        public static void RollToScore(TMP_Text textComponent, int start, int end, int step, Action callback = null, string numberpostfix = null)
        {
            RollToScoreConfig rtsc = new RollToScoreConfig();
            rtsc.textComponent = textComponent;
            rtsc.start = start;
            rtsc.end = end;
            rtsc.step = step;
            rtsc.callback = callback;
            rtsc.numberpostfix = numberpostfix;

            RollToScore(rtsc);
        }

        public static void RollToScore(RollToScoreConfig rtsc)
        {
            rtsc.textComponent.text = rtsc.start + (string.IsNullOrEmpty(rtsc.numberpostfix) ? "" : rtsc.numberpostfix);
            RollToStep(rtsc);
        }

        static void RollToStep(RollToScoreConfig rtsc)
        {
            int score = rtsc.start;
            DOTween.To(() => score, x => score = x+(rtsc.step-1), rtsc.end, .1f * Mathf.Abs(rtsc.end - rtsc.start)).OnUpdate(() =>
            {
                var currenttext = score + (string.IsNullOrEmpty(rtsc.numberpostfix) ? "" : rtsc.numberpostfix);
                if (currenttext != rtsc.textComponent.text)
                {
                    rtsc.textComponent.text =
                        currenttext;
                    if (rtsc.feedback != null)
                        DeAudioManager.Play(rtsc.feedback);
                }
            }
                    )
                .SetEase(Ease.Linear).OnComplete(() =>
                {
                    if (rtsc.callback != null)
                        rtsc.callback();
                });
        }

        public enum CharEffect
        {
            TEXT_DROP,
        }



    }
}

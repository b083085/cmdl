using CMDL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDL.Models
{
    public class NeuroV2 : NotifyPropertyChanged
    {
        private bool isReadOnly;
        private ClientV2 client;
        private string occupation;
        private string educationalAttainment;
        private string jobExperience;
        private string eligibility;
        private string iqTest;
        private string retake;
        private string personalityTest;
        private string others;
        private byte intelligence;
        private byte neuroticism;
        private byte extraversion;
        private byte openness;
        private byte agreeableness;
        private byte conscientiousness;
        private byte generalAppearance;
        private byte emotions;
        private byte thoughts;
        private byte cognition;
        private byte judgmentAndInsight;
        private string significantRemarks;
        private string remarks;
        private byte recommendation;
        private int psychometricianId;
        private string psychometrician;
        private int psychologistId;
        private string psychologist;
        private string printedBy;
        private byte b1;
        private byte b2;
        private byte c1;
        private byte c2;
        private byte c3;
        private byte c4;
        private byte d1;
        private byte d2;
        private byte d3;
        private byte d4;
        private bool isDraft;


        public string PrintedBy
        {
            get { return printedBy; }
            set
            {
                printedBy = value;
                OnPropertyChanged(nameof(PrintedBy));
            }
        }
        public string Psychologist
        {
            get { return psychologist; }
            set
            {
                psychologist = value;
                OnPropertyChanged(nameof(Psychologist));
            }
        }
        public int PsychologistId
        {
            get { return psychologistId; }
            set
            {
                psychologistId = value;
                OnPropertyChanged(nameof(PsychologistId));
            }
        }
        public string Psychometrician
        {
            get { return psychometrician; }
            set
            {
                psychometrician = value;
                OnPropertyChanged(nameof(Psychometrician));
            }
        }
        public int PsychometricianId
        {
            get { return psychometricianId; }
            set
            {
                psychometricianId = value;
                OnPropertyChanged(nameof(PsychometricianId));
            }
        }
        public byte Recommendation
        {
            get { return recommendation; }
            set
            {
                if (recommendation != value)
                {
                    recommendation = value;
                    OnPropertyChanged(nameof(Recommendation));
                }
            }
        }
        public string Remarks
        {
            get { return remarks; }
            set
            {
                remarks = value;
                OnPropertyChanged(nameof(Remarks));
            }
        }
        public string SignificantRemarks
        {
            get { return significantRemarks; }
            set
            {
                significantRemarks = value;
                OnPropertyChanged(nameof(SignificantRemarks));
            }
        }

        public byte Intelligence
        {
            get { return intelligence; }
            set
            {
                intelligence = value;
                OnPropertyChanged(nameof(Intelligence));
            }
        }
        public byte Neuroticism
        {
            get { return neuroticism; }
            set
            {
                neuroticism = value;
                OnPropertyChanged(nameof(Neuroticism));
            }
        }
        public byte Extraversion
        {
            get { return extraversion; }
            set
            {
                extraversion = value;
                OnPropertyChanged(nameof(Extraversion));

            }
        }
        public byte Openness
        {
            get { return openness; }
            set
            {
                openness = value;
                OnPropertyChanged(nameof(Openness));
            }
        }
        public byte Agreeableness
        {
            get { return agreeableness; }
            set
            {
                agreeableness = value;
                OnPropertyChanged(nameof(Agreeableness));
            }
        }
        public byte Conscientiousness
        {
            get { return conscientiousness; }
            set
            {
                conscientiousness = value;
                OnPropertyChanged(nameof(Conscientiousness));
            }
        }
        public byte GeneralAppearance
        {
            get { return generalAppearance; }
            set
            {
                generalAppearance = value;
                OnPropertyChanged(nameof(GeneralAppearance));
            }
        }
        public byte Emotions
        {
            get { return emotions; }
            set
            {
                emotions = value;
                OnPropertyChanged(nameof(Emotions));
            }
        }
        public byte Thoughts
        {
            get { return thoughts; }
            set
            {
                thoughts = value;
                OnPropertyChanged(nameof(Thoughts));
            }
        }
        public byte Cognition
        {
            get { return cognition; }
            set
            {
                cognition = value;
                OnPropertyChanged(nameof(Cognition));
            }
        }
        public byte JudgmentAndInsight
        {
            get { return judgmentAndInsight; }
            set
            {
                judgmentAndInsight = value;
                OnPropertyChanged(nameof(JudgmentAndInsight));
            }
        }

        public string Others
        {
            get { return others; }
            set
            {
                others = value;
                OnPropertyChanged(nameof(Others));
            }
        }
        public string PersonalityTest
        {
            get { return personalityTest; }
            set
            {
                personalityTest = value;
                OnPropertyChanged(nameof(PersonalityTest));
            }
        }
        public string Retake
        {
            get { return retake; }
            set
            {
                retake = value;
                OnPropertyChanged(nameof(Retake));
            }
        }
        public string IQTest
        {
            get { return iqTest; }
            set
            {
                iqTest = value;
                OnPropertyChanged(nameof(IQTest));
            }
        }
        public string Eligibility
        {
            get { return eligibility; }
            set
            {
                eligibility = value;
                OnPropertyChanged(nameof(Eligibility));
            }
        }
        public string JobExperience
        {
            get { return jobExperience; }
            set
            {
                jobExperience = value;
                OnPropertyChanged(nameof(JobExperience));
            }
        }
        public string EducationalAttainment
        {
            get { return educationalAttainment; }
            set
            {
                educationalAttainment = value;
                OnPropertyChanged(nameof(EducationalAttainment));
            }
        }
        public string Occupation
        {
            get { return occupation; }
            set
            {
                occupation = value;
                OnPropertyChanged(nameof(Occupation));
            }
        }
        public ClientV2 Client
        {
            get { return client; }
            set
            {
                client = value;
                OnPropertyChanged(nameof(Client));
            }
        }
        public bool IsReadOnly
        {
            get { return isReadOnly; }
            set
            {
                isReadOnly = value;
                OnPropertyChanged(nameof(IsReadOnly));
            }
        }
        public bool IsDraft
        {
            get { return isDraft; }
            set
            {
                isDraft = value;
                OnPropertyChanged(nameof(IsDraft));
            }
        }


        public byte D4
        {
            get { return d4; }
            set { d4 = value; OnPropertyChanged(nameof(D4)); }
        }
        public byte D3
        {
            get { return d3; }
            set { d3 = value; OnPropertyChanged(nameof(D3)); }
        }
        public byte D2
        {
            get { return d2; }
            set { d2 = value; OnPropertyChanged(nameof(D2)); }
        }
        public byte D1
        {
            get { return d1; }
            set { d1 = value; OnPropertyChanged(nameof(D1)); }
        }

        public byte C4
        {
            get { return c4; }
            set { c4 = value; OnPropertyChanged(nameof(C4)); }
        }
        public byte C3
        {
            get { return c3; }
            set { c3 = value; OnPropertyChanged(nameof(C3)); }
        }
        public byte C2
        {
            get { return c2; }
            set { c2 = value; OnPropertyChanged(nameof(C2)); }
        }
        public byte C1
        {
            get { return c1; }
            set { c1 = value; OnPropertyChanged(nameof(C1)); }
        }
        public byte B2
        {
            get { return b2; }
            set { b2 = value; OnPropertyChanged(nameof(B2)); }
        }
        public byte B1
        {
            get { return b1; }
            set { b1 = value; OnPropertyChanged(nameof(B1)); }
        }


    }
}

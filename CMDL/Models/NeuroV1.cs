using CMDL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDL.Models
{
    public class NeuroV1 : NotifyPropertyChanged
    {
        private bool isReadOnly;
        private ClientV2 client;
        private string subject;
        private string occupation;
        private string placeOfWork;
        private string education;
        private string religion;

        private sbyte a;

        private sbyte b1;
        private sbyte b2;

        private sbyte c1;
        private sbyte c2;
        private sbyte c3;
        private sbyte c4;

        private sbyte d1;
        private sbyte d2;
        private sbyte d3;
        private sbyte d4;
        

        private string jobExperience;
        private string eligibility;
        private string remarks;
        private string recommendation;
        private sbyte genApp;
        private sbyte attitude;
        private sbyte memory;
        private sbyte speech;
        private sbyte affectAndMood;
        private sbyte thoughtContent;
        private sbyte suicidality;
        private sbyte preOccupations;
        private sbyte cognitionThinking;
        private sbyte halucination;
        private string psychometrician;
        private string printedBy;
        private string psychologist;

        public string Psychologist
        {
            get { return psychologist; }
            set
            {
                psychologist = value;
                OnPropertyChanged(nameof(Psychologist));
            }
        }

        public string PrintedBy
        {
            get { return printedBy; }
            set
            {
                printedBy = value;
                OnPropertyChanged(nameof(PrintedBy));
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

        public sbyte Halucination
        {
            get { return halucination; }
            set
            {
                halucination = value;
                OnPropertyChanged(nameof(Halucination));
            }
        }
        public sbyte CognitionThinking
        {
            get { return cognitionThinking; }
            set
            {
                cognitionThinking = value;
                OnPropertyChanged(nameof(CognitionThinking));
            }
        }
        public sbyte PreOccupations
        {
            get { return preOccupations; }
            set
            {
                preOccupations = value;
                OnPropertyChanged(nameof(PreOccupations));
            }
        }
        public sbyte Suicidality
        {
            get { return suicidality; }
            set
            {
                suicidality = value;
                OnPropertyChanged(nameof(Suicidality));
            }
        }
        public sbyte ThoughtContent
        {
            get { return thoughtContent; }
            set
            {
                thoughtContent = value;
                OnPropertyChanged(nameof(ThoughtContent));
            }
        }
        public sbyte AffectAndMood
        {
            get { return affectAndMood; }
            set
            {
                affectAndMood = value;
                OnPropertyChanged(nameof(AffectAndMood));
            }
        }
        public sbyte Speech
        {
            get { return speech; }
            set
            {
                speech = value;
                OnPropertyChanged(nameof(Speech));
            }
        }
        public sbyte Memory
        {
            get { return memory; }
            set
            {
                memory = value;
                OnPropertyChanged(nameof(Memory));
            }
        }
        public sbyte Attitude
        {
            get { return attitude; }
            set
            {
                attitude = value;
                OnPropertyChanged(nameof(Attitude));
            }
        }
        public sbyte GenApp
        {
            get { return genApp; }
            set
            {
                genApp = value;
                OnPropertyChanged(nameof(GenApp));
            }
        }

        public string Recommendation
        {
            get { return recommendation; }
            set
            {
                recommendation = value;
                OnPropertyChanged(nameof(Recommendation));
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

        public sbyte D4
        {
            get { return d4; }
            set
            {
                d4 = value;
                OnPropertyChanged(nameof(D4));
            }
        }
        public sbyte D3
        {
            get { return d3; }
            set
            {
                d3 = value;
                OnPropertyChanged(nameof(D3));
            }
        }
        public sbyte D2
        {
            get { return d2; }
            set
            {
                d2 = value;
                OnPropertyChanged(nameof(D2));
            }
        }
        public sbyte D1
        {
            get { return d1; }
            set
            {
                d1 = value;
                OnPropertyChanged(nameof(D1));
            }
        }
        public sbyte C4
        {
            get { return c4; }
            set
            {
                c4 = value;
                OnPropertyChanged(nameof(C4));
            }
        }
        public sbyte C3
        {
            get { return c3; }
            set
            {
                c3 = value;
                OnPropertyChanged(nameof(C3));
            }
        }
        public sbyte C2
        {
            get { return c2; }
            set
            {
                c2 = value;
                OnPropertyChanged(nameof(C2));
            }
        }
        public sbyte C1
        {
            get { return c1; }
            set
            {
                c1 = value;
                OnPropertyChanged(nameof(C1));
            }
        }
        public sbyte B2
        {
            get { return b2; }
            set
            {
                if (b2 != value)
                {
                    b2 = value;
                    OnPropertyChanged(nameof(B2));
                }
            }
        }
        public sbyte B1
        {
            get { return b1; }
            set
            {
                if (b1 != value)
                {
                    b1 = value;
                    OnPropertyChanged(nameof(B1));
                }
            }
        }
        public sbyte A
        {
            get { return a; }
            set
            {
                if (a != value)
                {
                    a = value;
                    OnPropertyChanged(nameof(A));
                }
            }
        }


        public string Religion
        {
            get { return religion; }
            set
            {
                religion = value;
                OnPropertyChanged(nameof(Religion));
            }
        }

        public string Education
        {
            get { return education; }
            set
            {
                education = value;
                OnPropertyChanged(nameof(Education));
            }
        }

        public string PlaceOfWork
        {
            get { return placeOfWork; }
            set
            {
                placeOfWork = value;
                OnPropertyChanged(nameof(PlaceOfWork));
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

        public string Subject
        {
            get { return subject; }
            set
            {
                subject = value;
                OnPropertyChanged(nameof(Subject));
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
                if (isReadOnly != value)
                {
                    isReadOnly = value;
                    OnPropertyChanged(nameof(IsReadOnly));
                }
            }
        }


    }
}

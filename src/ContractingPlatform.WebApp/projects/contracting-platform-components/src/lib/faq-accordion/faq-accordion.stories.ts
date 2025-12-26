import type { Meta, StoryObj } from '@storybook/angular';
import { FaqAccordion } from './faq-accordion';

const meta: Meta<FaqAccordion> = {
  title: 'Components/FaqAccordion',
  component: FaqAccordion,
  tags: ['autodocs'],
  argTypes: {
    items: {
      control: 'object',
      description: 'Array of FAQ items',
    },
    multi: {
      control: 'boolean',
      description: 'Allow multiple panels open',
    },
  },
};

export default meta;
type Story = StoryObj<FaqAccordion>;

const kitchenFaqs = [
  {
    question: 'How long does a kitchen renovation take?',
    answer:
      "A typical kitchen renovation takes 4-8 weeks depending on the scope of work. We'll provide a detailed timeline during your consultation. Factors that affect duration include the size of the kitchen, complexity of the design, and any structural changes required.",
  },
  {
    question: 'Can I stay in my home during the renovation?',
    answer:
      'Yes, you can usually stay in your home during a kitchen renovation. We take precautions to minimize dust and noise, and we work to maintain access to essential utilities. However, you will not have access to your kitchen during the renovation period.',
  },
  {
    question: 'Do you handle permits and inspections?',
    answer:
      'Absolutely! We handle all necessary NYC permits and schedule all required inspections. Our team is fully licensed and familiar with all building codes and requirements in all five boroughs.',
  },
  {
    question: 'What is included in a full kitchen renovation?',
    answer:
      'A full kitchen renovation typically includes custom cabinetry, countertop installation, plumbing updates, electrical work, flooring, tile backsplash, and appliance installation. We can customize the scope based on your needs and budget.',
  },
];

export const KitchenFAQ: Story = {
  args: {
    items: kitchenFaqs,
    multi: false,
  },
};

export const GeneralFAQ: Story = {
  args: {
    items: [
      {
        question: 'Are you licensed and insured?',
        answer:
          "Yes, we are fully licensed by NYC and carry comprehensive insurance coverage. We're also BBB A+ rated and have been serving NYC homeowners for over 37 years.",
      },
      {
        question: 'Do you offer free estimates?',
        answer:
          'Yes! We offer free, no-obligation estimates for all our services. Contact us to schedule a consultation and we\'ll visit your property to discuss your project.',
      },
      {
        question: 'What areas do you serve?',
        answer:
          'We proudly serve all five NYC boroughs: Manhattan, Brooklyn, Queens, Bronx, and Staten Island. We have completed over 6,500 projects throughout the city.',
      },
      {
        question: 'Do you offer emergency services?',
        answer:
          'Yes, we offer 24/7 emergency services for water damage, fire damage, and other urgent situations. Call our emergency line anytime at (718) 550-2779.',
      },
    ],
    multi: false,
  },
};

export const MultipleOpen: Story = {
  args: {
    items: kitchenFaqs,
    multi: true,
  },
};

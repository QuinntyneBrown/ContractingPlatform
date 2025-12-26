import type { Meta, StoryObj } from '@storybook/angular';
import { StarRating } from './star-rating';

const meta: Meta<StarRating> = {
  title: 'Components/StarRating',
  component: StarRating,
  tags: ['autodocs'],
  argTypes: {
    rating: {
      control: { type: 'number', min: 0, max: 5, step: 0.5 },
      description: 'The rating value',
    },
    maxRating: {
      control: { type: 'number', min: 1, max: 10 },
      description: 'Maximum rating value',
    },
    size: {
      control: 'select',
      options: ['small', 'medium', 'large'],
      description: 'Star size',
    },
    showValue: {
      control: 'boolean',
      description: 'Show numeric value',
    },
  },
};

export default meta;
type Story = StoryObj<StarRating>;

export const FiveStars: Story = {
  args: {
    rating: 5,
    maxRating: 5,
    size: 'medium',
    showValue: false,
  },
};

export const FourStars: Story = {
  args: {
    rating: 4,
    maxRating: 5,
    size: 'medium',
    showValue: false,
  },
};

export const ThreeStars: Story = {
  args: {
    rating: 3,
    maxRating: 5,
    size: 'medium',
    showValue: false,
  },
};

export const WithValue: Story = {
  args: {
    rating: 4.5,
    maxRating: 5,
    size: 'medium',
    showValue: true,
  },
};

export const Small: Story = {
  args: {
    rating: 5,
    maxRating: 5,
    size: 'small',
    showValue: false,
  },
};

export const Large: Story = {
  args: {
    rating: 5,
    maxRating: 5,
    size: 'large',
    showValue: false,
  },
};
